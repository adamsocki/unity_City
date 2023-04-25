using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using static BuildingManager;
//using BuildingTypes;


public class BuildingManager : MonoBehaviour
{
    public GameObject residential1Prefab; // Assign your building prefab in the editor
    public GameObject portOfEntryPrefab; // Assign your building prefab in the editor

    public BuildingData residentialBuildingData;
    public BuildingData portOfEntryData;

    public EntityManager entityManager;
    //private List<BuildingInfo> buildings = new List<BuildingInfo>();
    //private List<GameObject> residentialBuildings = new List<GameObject>();
    //private List<GameObject> portOfEntryBuildings = new List<GameObject>();

    private Dictionary<BuildingType, List<GameObject>> buildingTypeMap = new Dictionary<BuildingType, List<GameObject>>();


    public void InitBuildingManager()
    {
        // Initialize the lists for each building type in the dictionary
        foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
        {
            buildingTypeMap[type] = new List<GameObject>();
        }
    }

    // You can call this method whenever you want to instantiate a building
    public void PlaceEntity(BuildingType buildingType, Vector3 position, Quaternion rotation)
    {
        GameObject newEntity = null;
        BuildingData buildingData = null;

        switch (buildingType)
        {
            case BuildingType.Residential1:
                newEntity = Instantiate(residential1Prefab, position, rotation);
                buildingData = residentialBuildingData;
                break;
            case BuildingType.PortOfEntry:
                newEntity = Instantiate(portOfEntryPrefab, position, rotation);
                buildingData = portOfEntryData;
                break;
                // Add more building types here
        }

        if (newEntity != null)
        {
            newEntity.layer = LayerMask.NameToLayer("Default");
            EntityManager.Handle handle = entityManager.AddEntity(newEntity);
            Entity entityComponent = newEntity.GetComponent<Entity>();
            entityComponent.SetHandle(handle);

            buildingTypeMap[buildingType].Add(newEntity);

            BuildingController buildingController = newEntity.GetComponent<BuildingController>();
            buildingController.Initialize(buildingData);

        }
    }

    public int GetBuildingCount()
    {
        int count = 0;
        return count;
       // return buildings.Count;
    }

}
