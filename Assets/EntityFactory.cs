using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class EntityFactory : MonoBehaviour
{
    public enum EntityType
    {
        Building,
        Road,
        Resident
    }

    public BuildingManager buildingManager;
    public RoadManager roadManager;
    public ResidentManager residentManager;
    public EntityManager entityManager;

    //public void CreateEntity(EntityType entityType, Vector3 position, Quaternion rotation, BuildingType? buildingType = null, BuildingData buildingData = null)
    //{
    //    switch (entityType)
    //    {
    //        case EntityType.Building:
    //            if (buildingType.HasValue)
    //            {
    //                buildingManager.PlaceEntity(buildingType.Value, position, rotation);
    //            }
    //            else
    //            {
    //                //Debug.LogError("No building type provided for EntityType.Building");
    //            }
    //            break;
    //        case EntityType.Road:
    //            roadManager.PlaceEntity(position, rotation);
    //            break;
    //        case EntityType.Resident:
    //            residentManager.PlaceEntity(position, rotation);
    //            break;
    //    }

    //   // return null;
    //}

    public void CreateEntity(PlayerObjectPlacer playerObjectPlacer)
    {
        switch (playerObjectPlacer.entityType)
        {
            case EntityType.Building:
                if (playerObjectPlacer.buildingType.HasValue)
                {
                    buildingManager.PlaceEntity(playerObjectPlacer.buildingType.Value, playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation, playerObjectPlacer.buildingData);
                }
                else
                {
                    //Debug.LogError("No building type provided for EntityType.Building");
                }
                break;
            case EntityType.Road:
                roadManager.PlaceEntity(playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation);
                break;
            case EntityType.Resident:
                residentManager.PlaceEntity(playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation);
                break;
        }

        // return null;
    }

}
