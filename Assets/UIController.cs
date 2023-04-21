using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public PlayerObjectPlacer playerObjectPlacer;
    public GameObject objectPrefab1;
    public GameObject objectPrefab2;
    public EntityManager entityManager; 
    public MouseInteractionManager mouseInteractionManager;

    [HideInInspector]
    public bool isInPlacementMode = false;

    public void UpdateUI()
    {
        if (Input.GetMouseButtonDown(0) && isInPlacementMode)
        {
            // Assuming objectToPlace is your object prefab and position is where you want to place it
            if (!mouseInteractionManager.IsObjectOverlap(playerObjectPlacer.objectToPlace, playerObjectPlacer.objectToPlace.transform.position))
            {
                // Instantiate the object and add it to the EntityManager
                entityManager.InstantiateObject(playerObjectPlacer);
            }
            else
            {
                // Object overlaps with existing objects, do not instantiate it
                print("this shouldn't be");
            }
            DeplaceObject();
        }
    }

    public void SetPlaceableObject1()
    {
        playerObjectPlacer.objectToPlace = objectPrefab1;
        isInPlacementMode = true;
    }

    public void SetPlaceableObject2()
    {
        playerObjectPlacer.objectToPlace = objectPrefab2;
        isInPlacementMode = true;
    }

    public void DeplaceObject()
    {
        isInPlacementMode = false;
    }

    
}
