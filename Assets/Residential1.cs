using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Residential1", menuName = "ScriptableObjects/Residential1", order = 1)]
public class Residential1 : BuildingData
{
    // Add any Residential1-specific properties here, if necessary

    // Override the UpdateBuilding method to implement specific update logic for Residential1 buildings
    public override void UpdateBuilding(GameObject building)
    {
        // Implement the specific update logic for Residential1 buildings
        Debug.Log("This is a Residential1 building");
    }

    // Add any other Residential1-specific methods here
}
