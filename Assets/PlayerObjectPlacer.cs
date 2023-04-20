using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPlacer : MonoBehaviour
{
    public GameObject objectToPlace;
    public LayerMask groundLayer;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void UpdateObjectPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            objectToPlace.transform.position = hit.point;
        }
    }   
}
