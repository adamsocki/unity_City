using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : MonoBehaviour
{
    public ResidentData residentData;
    public ResidentDataHolder residentDataHolder;


    private MovementController movementController;

    public void InitResident()
    {
        movementController = GetComponent<MovementController>();
    }

    public void UpdateResident()
    {
        movementController.UpdateMovement();
        // Add more controller updates here
    }

    // Call this function to set the destination for the resident
    public void MoveToDestination(Vector3 destination)
    {
        movementController.SetDestination(destination);
    }
}
