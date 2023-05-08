using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Unit Data", order = 1)]
public class UnitData : ScriptableObject
{
    public enum UnitType
    {
        Residential,
        Commercial,
        // Add other unit types here
    }
    public string unitName;
    //public GameObject unitPrefab;
    public UnitType unitType;
    // Add other unit-specific attributes here

    

    // Add methods for unit-specific behaviors here
}
