using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerObjectPlacer playerObjectPlacer;
    public GameObject roadPrefab;
   // public GameObject objectPrefab;
    public GameObject buildingPrefab;
    public EntityManager entityManager;
    public EntityFactory entityFactory;
    public BuildingManager buildingManager;
    public MouseInteractionManager mouseInteractionManager;

    public Text timeText;
    public Button increaseTimeButton;
    public Button decreaseTimeButton;
    public Button pauseTimeButton;

    public TimeManager timeManager;

    public Button placeBuildingButton;
    public Button placeRoadButton;




    public void InitUIController()
    {
        placeBuildingButton.onClick.AddListener(() => SetPlaceableObject(buildingPrefab, EntityFactory.EntityType.Building));
        placeRoadButton.onClick.AddListener(() => SetPlaceableObject(roadPrefab, EntityFactory.EntityType.Road));

        increaseTimeButton.onClick.AddListener(IncreaseTimeScale);
        decreaseTimeButton.onClick.AddListener(DecreaseTimeScale);
        pauseTimeButton.onClick.AddListener(PauseTimeScale);
    }

    [HideInInspector]
    public bool isInPlacementMode = false;

    public void UpdateUI()
    { 
        if (Input.GetMouseButtonDown(0) && isInPlacementMode)
        {
            if (!mouseInteractionManager.IsObjectOverlap(playerObjectPlacer.objectToPlace.transform.position))
            {
                // Use the EntityManager to instantiate the object.
                Debug.Log("Overlap check passed");
                entityManager.PlaceEntity(playerObjectPlacer.entityType, playerObjectPlacer.objectToPlace, playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation);
            }
            else
            { 
                // Object overlaps with existing objects, do not instantiate it
                print("this shouldn't be");
            }
            DeplaceObject();
        }
    
    }

    public void SetPlaceableObject(GameObject objectPrefab, EntityFactory.EntityType entityType)
    {
        playerObjectPlacer.objectToPlace = objectPrefab;
        playerObjectPlacer.entityType = entityType;
        isInPlacementMode = true;
    }

    public void DeplaceObject()
    {
        isInPlacementMode = false;
    }


    // Increase the time scale when the "Increase Time Scale" button is clicked
    public void IncreaseTimeScale()
    {
        timeManager.timeScale += 0.5f;
    }

    // Decrease the time scale when the "Decrease Time Scale" button is clicked
    public void DecreaseTimeScale()
    {
        timeManager.timeScale -= 0.5f;
    }

    // Pause the time scale when the "Pause Time Scale" button is clicked
    public void PauseTimeScale()
    {
        timeManager.timeScale = 0f;
    }
}


