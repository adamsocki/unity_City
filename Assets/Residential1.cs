using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Residential1", menuName = "ScriptableObjects/Residential1", order = 1)]
public class Residential1 : BuildingData, IMaintenanceEntity
{
    //public ResourceManager resourceManager;
    //// ... Other properties specific to Residential1
    //[SerializeField] private CostModifierData initialCost;
    //[SerializeField] private CostModifierData maintenanceCost;

    //public CostModifierData InitialCost { get => initialCost; }
    //public CostModifierData MaintenanceCost { get => maintenanceCost; }
    //// Add any Residential1-specific properties here, if necessary

    //// Override the UpdateBuilding method to implement specific update logic for Residential1 buildings
    //public override void UpdateBuilding(Building building)
    //{
    //    // Implement the specific update logic for Residential1 buildings
    //  //  Debug.Log("This is a Residential1 building");
    //}

    //// Implement the GetMaintenanceCostData method for the IMaintenanceEntity interface
    //public CostModifierData GetMaintenanceCostData()
    //{
    //    return MaintenanceCost;
    //}

    //// Implement the ApplyMaintenanceCost method for the IMaintenanceEntity interface
    //public void ApplyMaintenanceCost(ResourceManager resourceManager) // Add ResourceManager parameter
    //{
    //    ResourceData resourceData = resourceManager.GetResourceByType(maintenanceCost.resourceType);
    //    maintenanceCost.ApplyModifier(resourceData, "maintenance");
    //}


    //// Implement the HasMaintenanceCosts method for the IMaintenanceEntity interface
    //public bool HasMaintenanceCosts()
    //{
    //    // Check if the entity has maintenance costs (return true if it has maintenance costs, false otherwise)
    //    return true;
    //}
     


    // Add any other Residential1-specific methods here
}
