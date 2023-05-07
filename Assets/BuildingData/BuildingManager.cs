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
    public ResourceManager resourceManager;
    //private List<BuildingInfo> buildings = new List<BuildingInfo>();
    //private List<GameObject> residentialBuildings = new List<GameObject>();
    //private List<GameObject> portOfEntryBuildings = new List<GameObject>();

    private Dictionary<BuildingType, List<Building>> buildingTypeMap = new Dictionary<BuildingType, List<Building>>();

    

    private int totalBuildingCount = 0;

    public int TotalBuildingCount { get { return totalBuildingCount; } }


    public void InitBuildingManager()
    {
        // Initialize the lists for each building type in the dictionary
        foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
        {
            buildingTypeMap[type] = new List<Building>();
        }
    }

    // You can call this method whenever you want to instantiate a building
    public void PlaceEntity(BuildingType buildingType, Vector3 position, Quaternion rotation, BuildingData buildingData = null)
    {
        GameObject newEntityPrefab = null;

        switch (buildingType)
        {
            case BuildingType.Residential1:
                newEntityPrefab = Instantiate(residential1Prefab, position, rotation);
              //  buildingData = residentialBuildingData;
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
            // GameObject newEntityInstance = Instantiate(newEntityPrefab, position, rotation);
            newEntityPrefab.layer = LayerMask.NameToLayer("Building");
            EntityManager.Handle handle = entityManager.AddEntity(newEntityPrefab);
            Entity entityComponent = newEntityPrefab.GetComponent<Entity>();
            entityComponent.SetHandle(handle);

            newEntityPrefab.AddComponent<Building>(); // Add this line

            Building newEntity = newEntityPrefab.GetComponent<Building>();
            newEntity.data = buildingData; // Assign the building data

            


            newEntity.buildingID = Building.buildingIDCounter++;
            buildingTypeMap[buildingType].Add(newEntity);
            totalBuildingCount++;

           // BuildingController buildingController = newEntity.GetComponent<BuildingController>();
           // buildingController.Initialize(buildingData);

            Debug.Log($"New entity type: {newEntity.GetType()}");
            Debug.Log($"New name type: " + newEntity.data.buildingName);
            Debug.Log($"New name type: " + buildingData.buildingName);
            if (buildingData is IMaintenanceEntity maintenanceEntity)
            {
                Debug.Log($"Maintenance entity added to the list. List count: {resourceManager.maintenanceEntities.Count}");

                // Assuming you have a reference to your ResourceManager instance called resourceManager
                resourceManager.maintenanceEntities.Add(maintenanceEntity);
               
            }



            // Instantiate and add units to the buildingData object
            Debug.Log("buildingData type: " + buildingData.GetType()); // Add this line

            //if (buildingData is Residential1 residential1Data)
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        ResidentialUnit newResidentialUnit = Instantiate(residentialUnitDataTemplate);
            //        residential1Data.units.Add(newResidentialUnit);
            //        Debug.Log("Residential unit added.");
            //    }

            //    for (int i = 0; i < 6; i++)
            //    {
            //        CommercialUnit newCommercialUnit = Instantiate(commercialUnitDataTemplate);
            //        residential1Data.units.Add(newCommercialUnit);
            //        Debug.Log("Commercial unit added.");
            //    }
            //}
            //else if (buildingData is PortOfEntry portOfEntryData)
            //{
            //    // APPLY INITIAL COST MODIFER
            //    resourceManager.ApplyModifier(portOfEntryData.InitialCost, ResourceType.Cash, "construction");
            //    resourceManager.AddToMaintenanceCosts(ResourceType.Cash, portOfEntryData.MaintenanceCost.maintenanceCost);
            //}

            
        }
    }



    public int GetBuildingCount()
    {
        return totalBuildingCount;
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

    public (Building, ResidentialUnit) GetAvailableResidenciesByBuildingType(BuildingType buildingType)
    {
        List<Building> buildings = buildingTypeMap[buildingType];
        int buildingCount = buildings.Count;

        // Generate a random order for the indices

        List<int> indices = new List<int>();
        for (int i = 0; i < buildings.Count; i++)
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

        foreach (int index in indices)
        {
            BuildingController buildingController = buildings[index].GetComponent<BuildingController>();

            if (buildingController.buildingData is BuildingData buildingData)
            {
                foreach (UnitData unit in buildingData.units)
                {
                    if (unit is ResidentialUnit residentialUnit && !residentialUnit.isOccupied)
                    {
                        return (buildings[index], residentialUnit);
                    }
                }
            }
        }
        return (null, null);
    }

    public void AssignResidencyToResident(Resident resident, (Building, ResidentialUnit) residency)
    {
        // Assign the building and residential unit to the resident's data
        resident.residentData.home = residency.Item1.GetComponent<Building>();
        resident.residentData.hasHome = true;
        resident.residentDataHolder.assignedHomeBuildingID = residency.Item1.buildingID;
        resident.residentData.residentialUnit = residency.Item2;
        residency.Item2.isOccupied = true;
    }
    

    public List<Building> GetBuildingsByType(BuildingType buildingType)
    {
        if (buildingTypeMap.TryGetValue(buildingType, out List<Building> buildings))
        {
            return buildings;
        }
        else
        {
          //  Debug.LogWarning($"No buildings found for the given building type: {buildingType}");
            return new List<Building>();
        }
    }

    public Building GetRandomBuildingByType(BuildingType buildingType)
    {
        if (buildingTypeMap.TryGetValue(buildingType, out List<Building> buildings) && buildings.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, buildings.Count);
            return buildings[randomIndex];
        }
        else
        {
           // Debug.LogWarning($"No buildings found for the given building type: {buildingType}");
            return null;
        }
    }


    public Vector3 GetLocationOfBuilding(Building building)
    {
        if (building != null)
        {
            return building.transform.position;
        }
        else
        {
            Logger.LogWarning("GetLocationOfBuilding had an error. Building is null. Cannot get location.");
            return DefaultLocations.errorLocation; // You may want to return a different default value or throw an exception instead.
        }
    }



    public void UpdateBuildingManager()
    {
        foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
        { // update all building types for now
            UpdateBuildingsByType(type);
        }
        
    }



    //TODO IMPLEMENT THIS
    public void RemoveBuilding(Building building)
    {
        // ... Existing code to remove the building from the list and destroy it

        // Stop the coroutine for the removed building
    //    StopCoroutine(building.maintenanceCoroutine);
    }






}
