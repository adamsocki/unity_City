using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building Data", order = 0)]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public GameObject buildingPrefab;
    public List<UnitData> units;
    // Add other building-specific attributes here

    // Add methods for building-specific behaviors here

    public virtual void UpdateBuilding(GameObject building)
    {
        // Add logic to update the building here or leave it empty for the base classg
        Debug.Log("THis is a buidling");
    }
} 



