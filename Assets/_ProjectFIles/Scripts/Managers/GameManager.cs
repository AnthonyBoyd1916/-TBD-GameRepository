using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// Enum for example game states
[Serializable]
public enum GameState
{
    SplashScreen,
    MainMenu,
    Options,
    Paused,
    Running,
    GameOver
}

// GameManager is a persistent singleton class that manages the game
public class GameManager : PersistentSingleton<GameManager>
{
    public GameState CurrentGameState; // current game state
    public bool GameRunning = false; // is the game running?
    public float volume;

    #region Standard Unity Methods
    void Start()
    {
        Debug.Log("GameManager is running"); // delete this line after testing
        ChangeGameState(GameState.SplashScreen);
    }

    void Update()
    {
        Debug.Log("GameManager is updating"); // delete this line after testing

        if (GameRunning) ChangeGameState(GameState.Running);
        // Check the current game state
        switch (CurrentGameState)
        {
            case GameState.SplashScreen:
                // Do something
                break;
            case GameState.MainMenu:
                // Do something
                break;
            case GameState.Options:
                // Do something
                break;
            case GameState.Paused:
                // Do something
                break;
            case GameState.Running:
                Gameplay();
                break;
            case GameState.GameOver:
                // Do something
                break;
        }
    } // end of update
    #endregion
    // Method to handle the gameplay
    private void Gameplay()
    {
        throw new NotImplementedException(); // this is an exception handler in case the method is not implemented
    }
    // Method to change the game state
    public void ChangeGameState(GameState newGameState)
    {
        CurrentGameState = newGameState;
    }
}
