using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static BuildingManager;

public class UIController : MonoBehaviour
{
    public PlayerObjectPlacer playerObjectPlacer;
    public GameObject roadPrefab;
    public GameObject portOfEntryBuildingPrefab;
    public GameObject residentialBuildingPrefab;
    public EntityManager entityManager;
    public EntityFactory entityFactory;
    public BuildingManager buildingManager;
    public ResourceManager resourceManager;
    public MouseInteractionManager mouseInteractionManager;

    public TextMeshProUGUI timeText;
    public Button increaseTimeButton;
    public Button decreaseTimeButton;
    public Button pauseTimeButton;

    public TimeManager timeManager;

    public Button placeResidentialBuildingButton;
    public Button placePortOfEntryBuildingButton;
    public Button placeRoadButton;

    public TextMeshProUGUI buildingCountText;
    public TextMeshProUGUI cashText;

    [HideInInspector]
    public bool isInPlacementMode = false;



    public void InitUIController()
    {
        placeResidentialBuildingButton.onClick.AddListener(() => SetPlaceableObject(residentialBuildingPrefab, EntityFactory.EntityType.Building, BuildingType.Residential1));
        placePortOfEntryBuildingButton.onClick.AddListener(() => SetPlaceableObject(portOfEntryBuildingPrefab, EntityFactory.EntityType.Building, BuildingType.PortOfEntry));
        placeRoadButton.onClick.AddListener(() => SetPlaceableObject(roadPrefab, EntityFactory.EntityType.Road));

       // increaseTimeButton.onClick.AddListener(IncreaseTimeScale);
        //decreaseTimeButton.onClick.AddListener(DecreaseTimeScale);
       // pauseTimeButton.onClick.AddListener(PauseTimeScale);
    }


    public void UpdateUI()
    { 
        if (Input.GetMouseButtonDown(0) && isInPlacementMode)
        {
            if (!mouseInteractionManager.IsObjectOverlap(playerObjectPlacer.objectToPlace.transform.position) )
            {
                if (!playerObjectPlacer.inPlaceableRange)
                {
                    return;
                }
                // Use the EntityManager to instantiate the object.
                entityManager.PlaceEntity(playerObjectPlacer.entityType, playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation, playerObjectPlacer.buildingType);
            }
            else
            { 
                // Object overlaps with existing objects, do not instantiate it
                // TODO: Make indication that object cannot be placed here
                print("this shouldn't be");
            }
        }

        // Check if isInPlacementMode is true and Escape key is pressed to toggle placement mode off
        if (isInPlacementMode && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePlacementMode();
        }
        // DISPLAY TIME

        timeText.SetText("Time: " + timeManager.GetFormattedTime());

        DisplayBuildingCount();
        DisplayCash();

    }

    public void DisplayBuildingCount()
    {
        buildingCountText.SetText("Buildings: " + buildingManager.GetBuildingCount());
    }

    public void DisplayCash()
    {
        ResourceData cashResourceData = resourceManager.GetResourceByType(ResourceType.Cash);
        cashText.SetText("Cash: " + cashResourceData.currentAmount);
    }


    public void TogglePlacementMode()
    {
        isInPlacementMode = !isInPlacementMode;

        /*if (!isInPlacementMode)
        {
            // If exiting placement mode, reset object position
            DeplaceObject();
        }*/
    }


    public void SetPlaceableObject(GameObject objectPrefab, EntityFactory.EntityType entityType, BuildingType? buildingType = null)
    {
        if (buildingType.HasValue)
        {
            playerObjectPlacer.buildingType = buildingType.Value;
        }
        playerObjectPlacer.objectToPlace = objectPrefab;
        playerObjectPlacer.entityType = entityType;
        TogglePlacementMode();
    }

    public void DeplaceObject()
    {
        TogglePlacementMode();
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


