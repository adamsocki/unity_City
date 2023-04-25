using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Entity
{

    public string name;
    public int age;
    public int total;
    public int totalResidentialUnits;

    public BuildingData data;

    public void SetBuildingData(BuildingData buildingData)
    {
        data = buildingData;
    }

}
