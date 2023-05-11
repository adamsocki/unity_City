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
        movementController.InitMovementController();
        movementController.SetMoveCharacter(true);
        residentData.isMoving = true;
    }

    
    // Call this function to set the destination for the resident
    public void MoveToDestination(Vector3 destination)
    {
        movementController.SetDestination(destination);
    }


    public void UpdateResident()
    {
        movementController.UpdateMovementController();
        // Add more controller updates here
    }

}