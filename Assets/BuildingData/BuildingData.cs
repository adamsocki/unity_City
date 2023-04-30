using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building Data", order = 0)]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public Building buildingPrefab;
    public List<UnitData> units;
    // Add other building-specific attributes here

    // Add methods for building-specific behaviors here

    //// Cost modifier fields
    //[SerializeField] private CostModifierData initialCost;
    //[SerializeField] private CostModifierData maintenanceCost;

    //// Properties to access cost modifiers
    //public CostModifierData InitialCost { get => initialCost; }
    //public CostModifierData MaintenanceCost { get => maintenanceCost; }


    public virtual void UpdateBuilding(Building building)
    {
        // Add logic to update the building here or leave it empty for the base classg
        //Debug.Log("THis is a buidling");
    }
} 



