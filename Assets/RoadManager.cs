using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject buildingPrefab; // Assign your building prefab in the editor
    public EntityManager entityManager;

    // You can call this method whenever you want to instantiate a building
    public void PlaceEntity(Vector3 position, Quaternion rotation)
    {
        GameObject newEntity = Instantiate(buildingPrefab, position, rotation);

        if (newEntity != null)
        {
            newEntity.layer = LayerMask.NameToLayer("Default");
            EntityManager.Handle handle = entityManager.AddEntity(newEntity);
            Entity entityComponent = newEntity.GetComponent<Entity>();
            entityComponent.SetHandle(handle);
        }
    }
}
