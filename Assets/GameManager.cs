using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameStateManager gameStateManager;
    public ExecutionManager executionManager;
    
    public SaveLoadManager saveLoadManager;

    private GameData gameData;

    private void Start()
    {

        gameStateManager.SetState(GameState.Playing);

        executionManager.InitExecutionManager();



        //// Load game data from the save file
        //gameData = saveLoadManager.LoadGameData();

        //if (gameData == null)
        //{
        //    // Create a new GameData instance if no save file exists
        //    gameData = new GameData();
        //}

        //// Set the game data properties
        //gameData.exampleInt = 42;
        //gameData.exampleFloat = 3.14f;
        //gameData.exampleString = "Hello, World!";
    }



    private void Update()
    {
        switch (gameStateManager.CurrentState)
        {
            case GameState.MainMenu:
                // Show main menu UI and pause the game
                break;
            case GameState.Playing:
                // Hide all menus and resume the game
                executionManager.updatePlayingExecutionManager();
                break;
            case GameState.Paused:
                // Show pause menu and pause the game
                executionManager.updatePlayingExecutionManager();
                // TODO: Display Pause Menu
                break;
            case GameState.GameOver:
                // Show game over screen and pause the game
                break;
                // Handle other states as needed
        }
    }




    public void SaveGame()
    {
        saveLoadManager.SaveGameData(gameData);
    }

    public void LoadGame()
    {
        gameData = saveLoadManager.LoadGameData();
        // Use the loaded data to update the game state


    }

}
