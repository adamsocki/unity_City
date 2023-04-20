using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPlacer : MonoBehaviour
{
    [HideInInspector]
    public GameObject objectToPlace;

    public LayerMask groundLayer;

    private Camera mainCamera;
    public UIController uiController;

    private Vector3 hiddenPosition = new Vector3(0, -1000, 0);


    void Start()
    {
        mainCamera = Camera.main;
        if (objectToPlace)
        {
            objectToPlace.transform.position = hiddenPosition;
        }
    }

    public void UpdateObjectPosition()
    {
        if (!uiController.isObjectSelected)
        {
            if (objectToPlace)
            {
                objectToPlace.transform.position = hiddenPosition;
            }
            return; // exits the UpdateObjectPosition()
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            objectToPlace.transform.position = hit.point;
        }
    }
}
