using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public PlayerObjectPlacer playerObjectPlacer;
    public GameObject objectPrefab1;
    public GameObject objectPrefab2;

    [HideInInspector]
    public bool isObjectSelected = false;

    public void UpdateUI()
    {
        if (Input.GetMouseButtonDown(0) && isObjectSelected)
        {
            DeselectObject();
        }
    }

    public void SetPlaceableObject1()
    {
        playerObjectPlacer.objectToPlace = objectPrefab1;
        isObjectSelected = true;
    }

    public void SetPlaceableObject2()
    {
        playerObjectPlacer.objectToPlace = objectPrefab2;
        isObjectSelected = true;
    }

    public void DeselectObject()
    {
        isObjectSelected = false;
    }
}
