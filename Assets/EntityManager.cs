using System.Collections.Generic;
using UnityEngine;

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




    public void InstantiateObject(PlayerObjectPlacer playerObjectPlacer)
    {
        if (playerObjectPlacer.objectToPlace)
        {
            // Instantiate the object and add it to the EntityManager
            GameObject newObject = Instantiate(playerObjectPlacer.objectToPlace, playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation);
            Handle handle = AddEntity(newObject);

            // Set the handle on the Entity component of the instantiated object
            Entity entityComponent = newObject.GetComponent<Entity>();
            entityComponent.SetHandle(handle);

            // Remove the layerMask by setting the layer to a different layer
            newObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
