using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 destination; // Set the destination for the character to move to
    private float movementSpeed = 10.0f;
    private float stoppingDistance = 0.1f;

    public bool moveCharacter;
    public GameObject objectOwner;
    public ObjectType ownerObjectType;

    private Resident residentOwner;



    public void InitMovementController()
    {

        //ownerObject = objectOwner.GetComponent<GameObject>();
        ObjectTypeInfo ownerObjectTypeInfo = objectOwner.GetComponent<ObjectTypeInfo>();
        if (ownerObjectTypeInfo != null ) 
        { 
            ownerObjectType = ownerObjectTypeInfo.objectType;

            if ( ownerObjectType == ObjectType.Resident ) 
            {
                residentOwner = objectOwner.GetComponent<Resident>();
            }

        }


    }

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
            OnArrival();
        }
    }

    private void OnArrival()
    {
        // Do something when the object arrives at its destination
        if (ownerObjectType == ObjectType.Resident)
        {
            residentOwner.OnArrival(); 
        }

        moveCharacter = false;

    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    // Add this function to start or stop the movement
    public void SetMoveCharacter(bool move)
    {
        //if (ownerObjectType == ObjectType.Resident)
        //{
        //    residentOwner.OnDeparture();
        //}
        moveCharacter = move;
    }
}
