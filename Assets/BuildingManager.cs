using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using static BuildingManager;
//using BuildingTypes;


public class BuildingManager : MonoBehaviour
{
    public GameObject residential1Prefab; // Assign your building prefab in the editor
    public GameObject portOfEntryPrefab; // Assign your building prefab in the editor

    public ResidentialUnit residentialUnitDataTemplate;
    public CommercialUnit commercialUnitDataTemplate;


    public BuildingData residentialBuildingData;
    public BuildingData portOfEntryData;

    

    public EntityManager entityManager;
    //private List<BuildingInfo> buildings = new List<BuildingInfo>();
    //private List<GameObject> residentialBuildings = new List<GameObject>();
    //private List<GameObject> portOfEntryBuildings = new List<GameObject>();

    private Dictionary<BuildingType, List<Building>> buildingTypeMap = new Dictionary<BuildingType, List<Building>>();


    public void InitBuildingManager()
    {
        // Initialize the lists for each building type in the dictionary
        foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
        {
            buildingTypeMap[type] = new List<Building>();
        }
    }

    // You can call this method whenever you want to instantiate a building
    public void PlaceEntity(BuildingType buildingType, Vector3 position, Quaternion rotation)
    {
        GameObject newEntityPrefab = null;
        BuildingData buildingData = null;
        Debug.Log("Place Entity is callee.");
        switch (buildingType)
        {
            case BuildingType.Residential1:
                newEntityPrefab = Instantiate(residential1Prefab, position, rotation);
                buildingData = residentialBuildingData;
                Debug.Log("Residential1 buildingData assigned.");
                break;
            case BuildingType.PortOfEntry:
                newEntityPrefab = Instantiate(portOfEntryPrefab, position, rotation);
                buildingData = portOfEntryData;
                Debug.Log("PortOfEntry buildingData assigned.");
                break;
                // Add more building types here
        }
         
        if (newEntityPrefab != null)
        {
            GameObject newEntityInstance = Instantiate(newEntityPrefab, position, rotation);
            newEntityInstance.layer = LayerMask.NameToLayer("Default");
            EntityManager.Handle handle = entityManager.AddEntity(newEntityInstance);
            Entity entityComponent = newEntityInstance.GetComponent<Entity>();
            entityComponent.SetHandle(handle);

            newEntityInstance.AddComponent<Building>(); // Add this line

            Building newEntity = newEntityInstance.GetComponent<Building>();
            newEntity.data = buildingData; // Assign the building data

            newEntity.buildingID = Building.buildingIDCounter++;
            buildingTypeMap[buildingType].Add(newEntity);

            BuildingController buildingController = newEntity.GetComponent<BuildingController>();
            buildingController.Initialize(buildingData);

            // Instantiate and add units to the buildingData object
            Debug.Log("buildingData type: " + buildingData.GetType()); // Add this line

            if (buildingData is Residential1 residential1Data)
            {
                
                for (int i = 0; i < 4; i++)
                {
                    ResidentialUnit newResidentialUnit = Instantiate(residentialUnitDataTemplate);
                    residential1Data.units.Add(newResidentialUnit);
                    Debug.Log("Residential unit added.");
                }

                for (int i = 0; i < 6; i++)
                {
                    CommercialUnit newCommercialUnit = Instantiate(commercialUnitDataTemplate);
                    residential1Data.units.Add(newCommercialUnit);
                    Debug.Log("Commercial unit added.");
                }
            }
        }
    }

    public int GetBuildingCount()
    {
        int count = 0;
        return count;
       // return buildings.Count;
    }


    public void UpdateBuildingsByType(BuildingType buildingType)
    {
        BuildingData buildingData;

        switch (buildingType)
        {
            case BuildingType.Residential1:
                buildingData = residentialBuildingData;
                break;
            case BuildingType.PortOfEntry:
                buildingData = portOfEntryData;
                break;
            default:
                Debug.LogError("Invalid building type");
                return;
        }

        List<Building> buildings = buildingTypeMap[buildingType];
        foreach (Building building in buildings)
        {
            buildingData.UpdateBuilding(building);
        }
    }




    public Building GetAvailableResidentialBuilding()
    {
        List<Building> residentialBuildings = buildingTypeMap[BuildingType.Residential1];
        int buildingCount = residentialBuildings.Count;

        // Generate a random order for the indices

        List<int> indices = new List<int>();
        for (int i = 0; i < residentialBuildings.Count; i++)
        {
            indices.Add(i);
        }

        // Shuffle the indices
        System.Random random = new System.Random();
        int n = indices.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            int temp = indices[k];
            indices[k] = indices[n];
            indices[n] = temp;
        }


        //List<int> randomIndices = new List<int>(buildingCount);
        //for (int i = 0; i < buildingCount; i++)
        //{
        //    randomIndices.Add(i);
        //}
        //randomIndices = randomIndices.OrderBy(x => UnityEngine.Random.value).ToList();

        foreach (int index in indices)
        {
            Debug.Log("residentialBuildings: " + residentialBuildings);
            Debug.Log("index: " + index);
            Debug.Log("residentialBuildings[index]: " + residentialBuildings[index]);

            BuildingController buildingController = residentialBuildings[index].GetComponent<BuildingController>();
           
            if (buildingController.buildingData is Residential1 residential1Data)
            {
                foreach (UnitData unit in residential1Data.units)
                {
                    if (unit is ResidentialUnit residentialUnit && !residentialUnit.isOccupied)
                    {
                       // residentialUnit.isOccupied = true;
                        /*return buildingController;*/
                        return residentialBuildings[index];
                    }
                }
            }
        }

        return null;
    }


    public void UpdateBuildingManager()
    {
        foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
        { // update all building types for now
            UpdateBuildingsByType(type);
        }
        
    }


}
