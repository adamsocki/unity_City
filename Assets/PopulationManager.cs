using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour
{

   // public TimeManager timeManager;
    public EntityManager entityManager;
    public ResidentManager residentManager;
    public BuildingManager buildingManager;


    public float timeBetweenSpawn_test;
    public float timeSinceLastSpawn_test;

    private void TrySpawnResident()
    {
        // check port of entry
        List<Building> portOfEntryBuildings = buildingManager.GetBuildingsByType(BuildingType.PortOfEntry);
        if (portOfEntryBuildings != null && portOfEntryBuildings.Count > 0)
        {
            // checktimer
            if (timeSinceLastSpawn_test > timeBetweenSpawn_test)
            {
                residentManager.SpawnResident();
                timeSinceLastSpawn_test = 0.0f;
            }
        }
    }

    public void UpdatePopulationManager()
    {
        timeSinceLastSpawn_test += Time.deltaTime;
        TrySpawnResident();
    
        residentManager.UpdateResidents();
    
    }
}
