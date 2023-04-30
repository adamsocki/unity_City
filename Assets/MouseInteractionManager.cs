using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractionManager : MonoBehaviour
{
    // Add a reference to your EntityManager
    public EntityManager entityManager;
    public PlayerObjectPlacer playerObjectPlacer;

    public string groundLayerName = "Ground";
    private SelectableObject currentMousedOverObject;


    public void UpdateMouseInteraction()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            string hitLayerName = LayerMask.LayerToName(hit.transform.gameObject.layer);
            
            switch (hitLayerName)
            {
                case "Default":
                   // print("HITTING");
                    break;
                case "Ground":
                    // Ground detected
                   // print("Ground");
                    // Add your ground interaction logic here
                    break;
                default:
                    // Handle other layers
                    HandleObjectSelection(hit.transform);
                    break;
            }
        }
        else if (currentMousedOverObject != null)
        {
            currentMousedOverObject.MouseExit();
            currentMousedOverObject = null;
        }
    }

    private void HandleObjectSelection(Transform hitTransform)
    {
        SelectableObject hitObject = hitTransform.GetComponent<SelectableObject>();

        if (hitObject != null)
        {
            if (currentMousedOverObject != hitObject)
            {
                if (currentMousedOverObject != null)
                {
                    currentMousedOverObject.MouseExit();
                }
                currentMousedOverObject = hitObject;
                currentMousedOverObject.MouseOver();
            }

            if (Input.GetMouseButtonDown(0))
            {
                hitObject.MouseSelect();
            }
        }
        else if (currentMousedOverObject != null)
        {
            currentMousedOverObject.MouseExit();
            currentMousedOverObject = null;
        }
    }

    private int BuildLayerMaskWithoutPreviewObjectAndGround()
    {
        int layerMask = 0;
        for (int i = 0; i < 32; i++)
        {
            string layerName = LayerMask.LayerToName(i);
            if (layerName != "PreviewObject" && layerName != "Ground")
            {
                layerMask |= (1 << i);
            }
        }
        return layerMask;
    }

    

    public bool IsObjectOverlap(Vector3 position)
    {
        //Debug.Log("IsObjectOverlap called");
        // Get the bounds of the object
        Bounds bounds = playerObjectPlacer.GetBounds();
        bounds.center = position;

        // Check for overlaps using Physics.OverlapBox
        int layerMask = BuildLayerMaskWithoutPreviewObjectAndGround();
        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.extents, Quaternion.identity, layerMask);

        // If there are overlapping colliders, return true
        if (colliders.Length > 0)
        {
           // Debug.Log("Overlap detected");
            return true;
        }

        // No overlaps found, return false
        //Debug.Log("Overlap not detected");
        return false;
    }





}
