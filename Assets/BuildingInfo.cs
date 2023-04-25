using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo
{
    public GameObject building;
    public BuildingType buildingType;

    public BuildingInfo(GameObject building, BuildingType buildingType)
    {
        this.building = building;
        this.buildingType = buildingType;
    }
}
