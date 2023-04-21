using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CameraController cameraController;
    public PlayerObjectPlacer playerObjectPlacer;

    void Start()
    {
        

    }

    public void UpdatePlayer()
    {
        cameraController.UpdateCamera();
        playerObjectPlacer.UpdateObjectPosition();
        
    }
}
