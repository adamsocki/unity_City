using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentManager : MonoBehaviour
{
    public GameObject residentPrefab;
    public EntityManager entityManager;

    private List<Resident> residents = new List<Resident>();
   
    private float spawnTimer;
    public float spawnInterval = 10f;


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
        Resident resident = newResident.GetComponent<Resident>();
        residents.Add(resident);
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



    public void UpdateResidents()
    {
        for (int i = 0; i < residents.Count; i++)
        {
            residents[i].UpdateResident();
        }
    }

}
