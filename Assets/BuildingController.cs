using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public BuildingData buildingData;

    public void Initialize(BuildingData buildingData)
    {
        this.buildingData = buildingData;

        // Here you can set up any initial state or attributes for the building based on the buildingData.
    }

    //void Update()
    //{
    //    float elapsedTime = Time.deltaTime;
    //    //int resourcesGenerated = buildingData.GenerateResources(elapsedTime);
    //    // ... Do something with the generated resources
    //}
}
