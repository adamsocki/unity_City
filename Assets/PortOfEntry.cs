using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PortOfEntry", menuName = "ScriptableObjects/PortOfEntry", order = 1)]
public class PortOfEntry : BuildingData 
{
    // ... Other properties specific to PortOfEntry

    public override void UpdateBuilding(Building building)
    {
        //Debug.Log("This is port of entry");
        // Implement the specific update logic for PortOfEntry buildings
    }
}