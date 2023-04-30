using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PortOfEntry", menuName = "ScriptableObjects/PortOfEntry", order = 1)]
public class PortOfEntry : BuildingData 
{
    // ... Other properties specific to PortOfEntry
    [SerializeField] private CostModifierData initialCost;
    [SerializeField] private CostModifierData maintenanceCost;

    public CostModifierData InitialCost { get => initialCost; }
    public CostModifierData MaintenanceCost { get => maintenanceCost; }


    public override void UpdateBuilding(Building building)
    {
        //Debug.Log("This is port of entry");
        // Implement the specific update logic for PortOfEntry buildings
    }

    // Create a method to modify the initial cost
    public void ModifyInitialCost(int newConstructionCost, int newMaintenanceCost)
    {
        initialCost.constructionCost = newConstructionCost;
        initialCost.maintenanceCost = newMaintenanceCost;
    }

    // Create a method to modify the maintenance cost
    public void ModifyMaintenanceCost(int newConstructionCost, int newMaintenanceCost)
    {
        maintenanceCost.constructionCost = newConstructionCost;
        maintenanceCost.maintenanceCost = newMaintenanceCost;
    }
}