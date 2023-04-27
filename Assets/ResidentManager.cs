using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentManager : MonoBehaviour
{
    public GameObject residentPrefab;
    public ResidentData residentDataTemplate;
    
    public EntityManager entityManager;
    public BuildingManager buildingManager;

    private List<Resident> residents = new List<Resident>();
   
    private float spawnTimer;
    public float spawnInterval = 10f;


    private void AssignResidentData(Resident resident)
    {
        resident.residentData = Instantiate(residentDataTemplate);

        // Assign an available residential building as the resident's home
        Building availableBuilding = buildingManager.GetAvailableResidentialBuilding();
        if (availableBuilding != null)
        {
            resident.residentData.home = availableBuilding.GetComponent<Building>();
            resident.residentDataHolder.assignedHomeBuildingID = availableBuilding.buildingID; // Set the assigned home's buildingID
            Debug.Log(availableBuilding.buildingID);    
        }
        else
        {
            Debug.LogWarning("No available residential building found.");
        }

        // Set other residentData properties
        // ...
    }

    public void SpawnResident()
    {
        Vector3 spawnLocation_test = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject newResident = Instantiate(residentPrefab, spawnLocation_test, Quaternion.identity);
        Resident resident = newResident.GetComponent<Resident>();

        AssignResidentData(resident);

        resident.InitResident();
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
