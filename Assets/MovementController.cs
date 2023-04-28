using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 destination; // Set the destination for the character to move to
    private float movementSpeed = 10.0f;
    private float stoppingDistance = 0.1f; // A small distance to stop before reaching the destination

    private void Update()
    {
        UpdateMovement();
    }

    public void UpdateMovement()
    {
        // Calculate the direction vector to the destination
        Vector3 direction = (destination - transform.position).normalized;

        // Move the character towards the destination
        if (Vector3.Distance(transform.position, destination) > stoppingDistance)
        {
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }
}
