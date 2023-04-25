using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building Data", order = 0)]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public GameObject buildingPrefab;
    public UnitData[] units;
    // Add other building-specific attributes here

    // Add methods for building-specific behaviors here
} 
