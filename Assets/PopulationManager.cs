using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{

   // public TimeManager timeManager;
    public EntityManager entityManager;
    public ResidentManager residentManager;

    public float timeBetweenSpawn_test;
    public float timeSinceLastSpawn_test;

    private void TrySpawnResident()
    {
        if (timeSinceLastSpawn_test > timeBetweenSpawn_test)
        {
            residentManager.SpawnResident();
            timeSinceLastSpawn_test = 0.0f;
        }
    }

    /*public void SpawnResident()
    {
        // assign resident attributes;

        // get home position;
        // get Port of Entry Location;
        Vector3 spawnLocation = new Vector3 (0.0f, 0.0f, 0.0f);



        // entityManager.PlaceEntity(playerObjectPlacer.entityType, playerObjectPlacer.objectToPlace.transform.position, playerObjectPlacer.objectToPlace.transform.rotation, playerObjectPlacer.buildingType);
        entityManager.PlaceEntity(EntityFactory.EntityType.Resident, spawnLocation, Quaternion.identity);

    }*/

    public void UpdatePopulationManager()
    {
        timeSinceLastSpawn_test += Time.deltaTime;
        TrySpawnResident();
    }
}
