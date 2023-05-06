using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building Data", order = 0)]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public Building buildingPrefab;
    public List<UnitData> units;

    public BuildingData()
    {
        units = new List<UnitData>();

    }

    public void InitBuilding()
    {

    }


    public virtual void UpdateBuilding(Building building)
    {
        // Add logic to update the building here or leave it empty for the base classg
        //Debug.Log("THis is a buidling");
    }

   

}



