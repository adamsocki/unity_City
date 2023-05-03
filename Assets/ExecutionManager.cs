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
    public PopulationManager populationManager;
    public BuildingManager buildingManager;
    public ResourceManager resourceManager;
    public MenuManager menuManager;



    // Start is called before the first frame update
    public void InitExecutionManager()
    {
        resourceManager.InitResourceManager();
        uiController.InitUIController();
        menuManager.InitMenuManager();
        playerManager.InitPlayerManager();
        buildingManager.InitBuildingManager();
    }

    // Update is called once per frame
    public void updatePlayingExecutionManager()
    {
        //customUIController.UpdateUI();
        uiController.UpdateUI();
        playerManager.UpdatePlayer();
        populationManager.UpdatePopulationManager();
        timeManager.UpdateTimeManager();
        mouseInteractionManager.UpdateMouseInteraction();
        buildingManager.UpdateBuildingManager();
    }
}
