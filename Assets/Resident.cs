using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : MonoBehaviour
{
    public ResidentData residentData;
    public ResidentDataHolder residentDataHolder;

    public BuildingManager buildingManager;


    private MovementController movementController;

    public void InitResident()
    {
        movementController = GetComponent<MovementController>();
        movementController.InitMovementController();
       // movementController.SetMoveCharacter(true);
        residentData.isMoving = true;
    }

    
    // Call this function to set the destination for the resident
    //public void MoveToDestination(Vector3 destination)
    //{
    //    movementController.SetDestination(destination);
    //}



    public void OnArrival()
    {
        residentData.isAtDestination = true;
        residentData.isMoving = false;
        residentData.isInTransit = false;
        residentData.isInTransit = false;
    }

    public void OnDeparture(Building destinationBuilding)
    {
        movementController.SetMoveCharacter(true);

        if (destinationBuilding != null)
        {
            movementController.SetDestination(buildingManager.GetLocationOfBuilding(destinationBuilding));

        }
        else
        {
            movementController.SetDestination(new Vector3(0.0f, 1.0f, 0.0f));
        }

        residentData.isAtDestination = false;
        residentData.isMoving = true;
        residentData.isInTransit = true;
    }

    public void InTransit()
    {

    }





    public void UpdateResident()
    {

        movementController.UpdateMovementController();
        // Add more controller updates here
    }

}