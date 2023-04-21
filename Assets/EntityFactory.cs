using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    public enum EntityType
    {
        Building,
        Road
    }

    public BuildingManager buildingManager;
    public RoadManager roadManager;
    public EntityManager entityManager;

    public void CreateEntity(EntityType entityType, Vector3 position, Quaternion rotation)
    {
        switch (entityType)
        {
            case EntityType.Building:
                buildingManager.PlaceEntity(position, rotation);
                break;
            case EntityType.Road:
                roadManager.PlaceEntity(position, rotation);
                break;
        }

       // return null;
    }
}
