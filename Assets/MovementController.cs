using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private float movementSpeed = 10.0f;


    public void UpdateMovement()
    {
        Vector3 movement = Vector3.zero;

        movement += new Vector3(movementSpeed * Time.deltaTime, 0, 0);

        this.transform.Translate(movement, Space.World);
    }


}
