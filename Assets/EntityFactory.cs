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

    public void CreateEntity(EntityType entityType, Vector3 position, Quaternion rotation, BuildingType? buildingType = null)
    {
        switch (entityType)
        {
            case EntityType.Building:
                if (buildingType.HasValue)
                {
                    buildingManager.PlaceEntity(buildingType.Value, position, rotation);
                }
                else
                {
                    //Debug.LogError("No building type provided for EntityType.Building");
                }
                break;
            case EntityType.Road:
                roadManager.PlaceEntity(position, rotation);
                break;
            case EntityType.Resident:
                residentManager.PlaceEntity(position, rotation);
                break;
        }

       // return null;
    }
}
