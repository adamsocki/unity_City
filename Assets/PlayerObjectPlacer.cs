using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPlacer : MonoBehaviour
{
    [HideInInspector]
    public GameObject objectToPlace;

    public EntityFactory.EntityType entityType;
    public BuildingType buildingType;


    public LayerMask groundLayer;

    private Camera mainCamera;
    public UIController uiController;

    private Vector3 hiddenPosition = new Vector3(0, -1000, 0);
    public bool inPlaceableRange;


    public void InitPlayerObjectPlacer()
    {
        mainCamera = Camera.main;
        if (objectToPlace)
        {
            objectToPlace.transform.position = hiddenPosition; 
            objectToPlace.layer = LayerMask.NameToLayer("PreviewObject");
        }
        if (uiController == null)
        {
            Debug.LogError("UIController not assigned in the PlayerObjectPlacer script.");
        }
    }

    public Bounds GetBounds()
    {
        if (objectToPlace != null)
        {
            Collider collider = objectToPlace.GetComponent<Collider>();
            if (collider != null)
            {
                return collider.bounds;
            }
        }
        return new Bounds();
    }

    public void UpdateObjectPosition()
    {   
        if (!uiController.isInPlacementMode)
        {
            if (objectToPlace)
            {
                objectToPlace.transform.position = hiddenPosition;
                inPlaceableRange = false;
            }
            return; // exits the UpdateObjectPosition()
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer)) // detect if in placeable Range (ground)
        {
            objectToPlace.transform.position = hit.point;
            inPlaceableRange = true;
        }
        else
        {
            objectToPlace.transform.position = hiddenPosition;
            inPlaceableRange = false;
        }

    }
}
