using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CameraController cameraController;
    public PlayerObjectPlacer playerObjectPlacer;

    public void InitPlayerManager()
    {
        playerObjectPlacer.InitPlayerObjectPlacer();
    }

    public void UpdatePlayer()
    {
        cameraController.UpdateCamera();
        playerObjectPlacer.UpdateObjectPosition();
        
    }
}
