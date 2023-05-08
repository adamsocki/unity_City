using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building Data", order = 0)]
public class BuildingData : ScriptableObject, IMaintenanceEntity
{
    public string buildingName;
    public Building buildingPrefab;
    public Dictionary<UnitData.UnitType, List<UnitData>> unitsByType;



    public BuildingData()
    {
        unitsByType = new Dictionary<UnitData.UnitType, List<UnitData>>();


    }

    public void InitBuilding()
    {

    }

    public void AddUnit(UnitData unit)
    {
        if (!unitsByType.ContainsKey(unit.unitType))
        {
            unitsByType[unit.unitType] = new List<UnitData>();
        }
        unitsByType[unit.unitType].Add(unit);
    }

    public int GetUnitCountByType(UnitData.UnitType unitType)
    {
        if (unitsByType.ContainsKey(unitType))
        {
            return unitsByType[unitType].Count;
        }
        return 0;
    }

    public virtual void UpdateBuilding(Building building)
    {
        // Add logic to update the building here or leave it empty for the base classg
        //Debug.Log("THis is a buidling");
    }


    public ResourceManager resourceManager;
    // ... Other properties specific to PortOfEntry
    [SerializeField] private CostModifierData costModifierData;
    //[SerializeField] private CostModifierData maintenanceCost;

    public CostModifierData CostModifierData
    {
        get => costModifierData;
        set => costModifierData = value;
    }
    //public CostModifierData MaintenanceCost { get => maintenanceCost; }

    //public CostModifierData CostData { get; private set; }

    //public PortOfEntry(CostModifierData costData)
    //{
    //    CostData = costData;
    //}
    //public override void UpdateBuilding(Building building)
    //{
    //    //Debug.Log("This is port of entry");
    //    // Implement the specific update logic for PortOfEntry buildings
    //}

    // Create a method to modify the initial cost
    public void ModifyInitialCost(int newConstructionCost)
    {
        costModifierData.constructionCost = newConstructionCost;
        //initialCost.maintenanceCost = newMaintenanceCost;
    }

    // Create a method to modify the maintenance cost
    public void ModifyMaintenanceCost(int newMaintenanceCost)
    {
        //maintenanceCost.constructionCost = newConstructionCost;
        costModifierData.maintenanceCost = newMaintenanceCost;
    }

    // Implement the GetMaintenanceCostData method for the IMaintenanceEntity interface
    public CostModifierData GetCostData()
    {
        return CostModifierData;
    }

    // Implement the ApplyMaintenanceCost method for the IMaintenanceEntity interface
    public void ApplyMaintenanceCost(ResourceManager resourceManager) // Add ResourceManager parameter
    {
        // Now you can use resourceManager in this method without having it as a serialized field
        ResourceData resourceData = resourceManager.GetResourceByType(costModifierData.resourceType);
        costModifierData.ApplyModifier(resourceData, "maintenance");
    }


    // Implement the HasMaintenanceCosts method for the IMaintenanceEntity interface
    public bool HasMaintenanceCosts()
    {
        // Check if the entity has maintenance costs (return true if it has maintenance costs, false otherwise)
        return true;
    }
}



