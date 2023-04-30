using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class EntityManager : MonoBehaviour
{
    public class Handle
    {
        public int id;

        public Handle(int id)
        {
            this.id = id;
        }
    }

    public class Index
    {
        public GameObject gameObject;

        public Index(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }

    public EntityFactory entityFactory;
    private Dictionary<int, Index> entities = new Dictionary<int, Index>();
    private int nextEntityId = 0;

    public Handle AddEntity(GameObject gameObject)
    {
        int id = nextEntityId++;
        entities.Add(id, new Index(gameObject));
        return new Handle(id);
    }

    public Index GetEntity(Handle handle)
    {
        if (entities.TryGetValue(handle.id, out Index index))
        {
            return index;
        }
        return null;
    }

    public void RemoveEntity(Handle handle)
    {
        entities.Remove(handle.id);
    }
    public void PlaceEntity(EntityFactory.EntityType entityType, Vector3 position, Quaternion rotation, BuildingType? buildingType = null)
    {
        entityFactory.CreateEntity(entityType, position, rotation, buildingType);
    }


    

}
