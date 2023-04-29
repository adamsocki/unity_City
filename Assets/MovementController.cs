using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 destination; // Set the destination for the character to move to
    private float movementSpeed = 10.0f;
    private float stoppingDistance = 0.1f;

    private bool moveCharacter;

    public void UpdateMovementController()
    { 
        if (moveCharacter) // Check if the character should move
        {
            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        // Calculate the direction vector to the destination
        Vector3 direction = (destination - transform.position).normalized;

        // Move the character towards the destination
        if (Vector3.Distance(transform.position, destination) > stoppingDistance)
        {
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
        else
        {
            moveCharacter = false;
        }
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    // Add this function to start or stop the movement
    public void SetMoveCharacter(bool move)
    {
        moveCharacter = move;
    }
}
