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


}
