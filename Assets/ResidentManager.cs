using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentManager : MonoBehaviour
{
    public GameObject residentPrefab;
   // public Transform spawnPoint;
    public float spawnInterval = 10f;

    public EntityManager entityManager;

    private List<GameObject> residents = new List<GameObject>();
    private float spawnTimer;


    //void Update()
    //{
    //    spawnTimer += Time.deltaTime;
    //    if (spawnTimer >= spawnInterval)
    //    {
    //        SpawnResident();
    //        spawnTimer = 0f;
    //    }
    //}

    public void SpawnResident()
    {
        Vector3 spawnLocation_test = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject newResident = Instantiate(residentPrefab, spawnLocation_test, Quaternion.identity);
        residents.Add(newResident);
    }

    public int GetResidentCount()
    {
        return residents.Count;
    }

    public void PlaceEntity(Vector3 position, Quaternion rotation)
    {
        GameObject newEntity = Instantiate(residentPrefab, position, rotation);

        if (newEntity != null)
        {
            newEntity.layer = LayerMask.NameToLayer("Default");
            EntityManager.Handle handle = entityManager.AddEntity(newEntity);
            Entity entityComponent = newEntity.GetComponent<Entity>();
            entityComponent.SetHandle(handle);
        }
    }

}
