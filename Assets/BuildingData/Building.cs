using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Entity
{

    public string name;
    public int age;
    public int total;
    public int totalResidentialUnits;
    public int totalCommercialUnits;

    public BuildingData data;
    public static int buildingIDCounter = 10;
    public int buildingID;


    public void SetBuildingData(BuildingData buildingData)
    {
        data = buildingData;
    }

    
}
