using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionManager : MonoBehaviour
{

    public PlayerManager playerManager;
    public UIController uiController;
    public TimeManager timeManager;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        uiController.UpdateUI();
        playerManager.UpdatePlayer();
        timeManager.UpdateTimeManager();
    }
}
