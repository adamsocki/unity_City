using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentManager : MonoBehaviour
{
    public GameObject residentPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 10f;

    private List<GameObject> residents = new List<GameObject>();
    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnResident();
            spawnTimer = 0f;
        }
    }

    private void SpawnResident()
    {
        GameObject newResident = Instantiate(residentPrefab, spawnPoint.position, Quaternion.identity);
        residents.Add(newResident);
    }

    public int GetResidentCount()
    {
        return residents.Count;
    }
}
