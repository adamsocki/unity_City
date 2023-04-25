using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : MonoBehaviour
{
    public string name;
    public int age;
    public Building home;

    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    public void UpdateResident()
    {
        movementController.UpdateMovement();
        // Add more controller updates here
    }


}
