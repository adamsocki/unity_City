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

    public GridManager gridManager;
    //private List<BuildingInfo> buildings = new List<BuildingInfo>();
    //private List<GameObject> residentialBuildings = new List<GameObject>();
    //private List<GameObject> portOfEntryBuildings = new List<GameObject>();

    

    private Dictionary<BuildingType, List<Building>> buildingTypeMap = new Dictionary<BuildingType, List<Building>>();
    
    // unit manager
   
    private Dictionary<UnitData.UnitType, List<UnitData>> unitTypeMap = new Dictionary<UnitData.UnitType, List<UnitData>>();


    

    private int totalBuildingCount = 0;

    public int TotalBuildingCount { get { return totalBuildingCount; } }

    private int totalResidentialUnitCount = 0;
    private int totalCommercialUnitCount = 0;

    public int TotalResidentialCount { get { return totalResidentialUnitCount; } }
    public int TotalCommercialUnitCount { get { return totalCommercialUnitCount; } }


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
                //buildingData = portOfEntryData;
                Debug.Log("PortOfEntry buildingData assigned.");

                break;
                // Add more building types here
        }
         
        if (newEntityPrefab != null)
        {
            // GameObject newEntityInstance = Instantiate(newEntityPrefab, position, rotation);
            newEntityPrefab.layer = LayerMask.NameToLayer("Building");
            Debug.Log("LayerNamed building");
            EntityManager.Handle handle = entityManager.AddEntity(newEntityPrefab);
            Entity entityComponent = newEntityPrefab.GetComponent<Entity>();
            entityComponent.SetHandle(handle);

            newEntityPrefab.AddComponent<Building>(); // Add this line

            Building newEntity = newEntityPrefab.GetComponent<Building>();
            newEntity.data = buildingData; // Assign the building data

           


            newEntity.buildingID = Building.buildingIDCounter++;
            buildingTypeMap[buildingType].Add(newEntity);
            totalBuildingCount++;
            ResourceData resourceData = resourceManager.GetResourceByType(newEntity.data.CostModifierData.resourceType);
            newEntity.data.CostModifierData.ApplyModifier(resourceData, "construction");
            if (buildingData is IMaintenanceEntity maintenanceEntity)
            {
                resourceManager.maintenanceEntities.Add(maintenanceEntity);
                resourceManager.AddToMaintenanceCosts(newEntity.data.CostModifierData.resourceType, newEntity.data.CostModifierData.maintenanceCost);
            }

            int i = 0;
            // loop through all units in the buildingData and add them to the unitTypeMap
            foreach (UnitData.UnitType unitType in buildingData.unitsByType.Keys)
            {
              //  i++;
               // Debug.Log(i);
                if (!unitTypeMap.ContainsKey(unitType))
                {
                    unitTypeMap[unitType] = new List<UnitData>();
                }
                unitTypeMap[unitType].AddRange(buildingData.unitsByType[unitType]);

                if (unitType == UnitData.UnitType.Residential)
                {
                    totalResidentialUnitCount += buildingData.unitsByType[unitType].Count;
                    Debug.Log(totalResidentialUnitCount);
                }
                else if (unitType == UnitData.UnitType.Commercial)
                {
                    totalCommercialUnitCount += buildingData.unitsByType[unitType].Count;
                }
            }

            // SET THE GRID
            Bounds bounds = newEntityPrefab.GetComponent<MeshRenderer>().bounds;
            Vector3[] corners = new Vector3[4];

            corners[0] = bounds.center + new Vector3(bounds.extents.x, 0, bounds.extents.z);
            corners[1] = bounds.center + new Vector3(-bounds.extents.x, 0, bounds.extents.z);
            corners[2] = bounds.center + new Vector3(-bounds.extents.x, 0, -bounds.extents.z);
            corners[3] = bounds.center + new Vector3(bounds.extents.x, 0, -bounds.extents.z);



            foreach(Vector3 corner in corners)
            {
                PathNode node = gridManager.grid.GetNodeFromWorldPosition(corner);
                if (node != null)
                {
                    node.isWalkable = false;
                }
                Debug.DrawLine(corner, Vector3.up, Color.blue, 20) ;

            }



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
        //Debug.Log(buildingCount);
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
            Building building = buildings[index];
            foreach (UnitData.UnitType unitType in building.data.unitsByType.Keys)
            {
                foreach (UnitData unit in building.data.unitsByType[unitType])
                {
                    if (unit is ResidentialUnit residentialUnit && !residentialUnit.isOccupied)
                    {
                        Debug.Log("there are places to stay");
                        return (buildings[index], residentialUnit);
                    }
                }
            }
        }

        return (null, null);
    }

    public (Building, CommercialUnit) GetAvailableCommericalUnitsByBuildingType(BuildingType buildingType)
    {
        List<Building> buildings = buildingTypeMap[buildingType];
        int buildingCount = buildings.Count;
        //Debug.Log(buildingCount);
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
            Building building = buildings[index];
            foreach (UnitData.UnitType unitType in building.data.unitsByType.Keys)
            {
                foreach (UnitData unit in building.data.unitsByType[unitType])
                {
                    if (unit is CommercialUnit commercialUnit && !commercialUnit.isOccupied)
                    {
                        //Debug.Log("there are places to stay");
                        return (buildings[index], commercialUnit);
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
        resident.residentData.unitAssignedHome = residency.Item2;
        residency.Item2.isOccupied = true;
    }
    
    public void AssignCommericalUnitToResident(Resident resident, (Building, CommercialUnit) commercial)
    {
        resident.residentData.work = commercial.Item1.GetComponent<Building>();
        resident.residentData.isEmployed = true;
        resident.residentDataHolder.assignedWorkBuildingID = commercial.Item1.buildingID;
        resident.residentData.unitAssignedWork = commercial.Item2;
        commercial.Item2.isOccupied = true;
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
