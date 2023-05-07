using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PortOfEntry", menuName = "ScriptableObjects/PortOfEntry", order = 1)]
public class PortOfEntry : BuildingData, IMaintenanceEntity
{
    //public ResourceManager resourceManager;
    //// ... Other properties specific to PortOfEntry
    //[SerializeField] private CostModifierData initialCost;
    //[SerializeField] private CostModifierData maintenanceCost;

    //public CostModifierData InitialCost { get => initialCost; }
    //public CostModifierData MaintenanceCost { get => maintenanceCost; }

    ////public CostModifierData CostData { get; private set; }

    ////public PortOfEntry(CostModifierData costData)
    ////{
    ////    CostData = costData;
    ////}
    //public override void UpdateBuilding(Building building)
    //{
    //    //Debug.Log("This is port of entry");
    //    // Implement the specific update logic for PortOfEntry buildings
    //}

    //// Create a method to modify the initial cost
    //public void ModifyInitialCost(int newConstructionCost, int newMaintenanceCost)
    //{
    //    initialCost.constructionCost = newConstructionCost;
    //    initialCost.maintenanceCost = newMaintenanceCost;
    //}

    //// Create a method to modify the maintenance cost
    //public void ModifyMaintenanceCost(int newConstructionCost, int newMaintenanceCost)
    //{
    //    maintenanceCost.constructionCost = newConstructionCost;
    //    maintenanceCost.maintenanceCost = newMaintenanceCost;
    //}

    //// Implement the GetMaintenanceCostData method for the IMaintenanceEntity interface
    //public CostModifierData GetMaintenanceCostData()
    //{
    //    return MaintenanceCost;
    //}

    //// Implement the ApplyMaintenanceCost method for the IMaintenanceEntity interface
    //public void ApplyMaintenanceCost(ResourceManager resourceManager) // Add ResourceManager parameter
    //{
    //    // Now you can use resourceManager in this method without having it as a serialized field
    //    ResourceData resourceData = resourceManager.GetResourceByType(maintenanceCost.resourceType);
    //    maintenanceCost.ApplyModifier(resourceData, "maintenance");
    //}


    //// Implement the HasMaintenanceCosts method for the IMaintenanceEntity interface
    //public bool HasMaintenanceCosts()
    //{
    //    // Check if the entity has maintenance costs (return true if it has maintenance costs, false otherwise)
    //    return  true;
    //}
}