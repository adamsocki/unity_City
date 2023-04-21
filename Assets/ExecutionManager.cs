using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionManager : MonoBehaviour
{

    public PlayerManager playerManager;
    public UIController uiController;
   // public CustomUIController customUIController;
    public TimeManager timeManager;
    public MouseInteractionManager mouseInteractionManager;



    // Start is called before the first frame update
    void Start()
    {
        uiController.InitUIController();
    }

    // Update is called once per frame
    void Update()
    {
        //customUIController.UpdateUI();
        uiController.UpdateUI();
        playerManager.UpdatePlayer();
        timeManager.UpdateTimeManager();
        mouseInteractionManager.UpdateMouseInteraction();
    }
}
