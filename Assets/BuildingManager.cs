using UnityEngine;
using static BuildingManager;

public class BuildingManager : MonoBehaviour
{
    public GameObject residential1Prefab; // Assign your building prefab in the editor
    public GameObject portOfEntryPrefab; // Assign your building prefab in the editor



    public EntityManager entityManager;
    private int buildingCount;


    public enum BuildingType
    {
        Residential1,
        PortOfEntry
    }

    // You can call this method whenever you want to instantiate a building
    public void PlaceEntity(BuildingType buildingType, Vector3 position, Quaternion rotation)
    {
        GameObject newEntity = null;

        switch (buildingType)
        {
            case BuildingType.Residential1:
                newEntity = Instantiate(residential1Prefab, position, rotation);
                break;
            case BuildingType.PortOfEntry:
                newEntity = Instantiate(portOfEntryPrefab, position, rotation);
                break;
                // Add more building types here
        }

        if (newEntity != null)
        {
            newEntity.layer = LayerMask.NameToLayer("Default");
            EntityManager.Handle handle = entityManager.AddEntity(newEntity);
            Entity entityComponent = newEntity.GetComponent<Entity>();
            entityComponent.SetHandle(handle);

            buildingCount++;
        }
    }

    public int GetBuildingCount()
    {
        return buildingCount;
    }

}
