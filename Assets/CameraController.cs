using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;

    public float movementSpeed = 5.0f;
    public float edgeMovementSpeed = 5.0f;
    public float verticalMovementSpeed = 5.0f;
    public float edgeBorderSize = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateCamera()
    {
        // WASD Movement
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        camera.transform.Translate(horizontal, 0, vertical);

        // Edge Movement
        Vector3 edgeMovement = Vector3.zero;

        if (Input.mousePosition.x <= edgeBorderSize)
            edgeMovement += new Vector3(-edgeMovementSpeed * Time.deltaTime, 0, 0);

        if (Input.mousePosition.x >= Screen.width - edgeBorderSize)
            edgeMovement += new Vector3(edgeMovementSpeed * Time.deltaTime, 0, 0);

        if (Input.mousePosition.y <= edgeBorderSize)
            edgeMovement += new Vector3(0, 0, -edgeMovementSpeed * Time.deltaTime);

        if (Input.mousePosition.y >= Screen.height - edgeBorderSize)
            edgeMovement += new Vector3(0, 0, edgeMovementSpeed * Time.deltaTime);

        camera.transform.Translate(edgeMovement, Space.World);

        // Vertical Movement
        float verticalMovement = 0.0f;

        if (Input.GetKey(KeyCode.P))
            verticalMovement = verticalMovementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.O))
            verticalMovement = -verticalMovementSpeed * Time.deltaTime;

        camera.transform.Translate(0, verticalMovement, 0, Space.World);
    }

}

