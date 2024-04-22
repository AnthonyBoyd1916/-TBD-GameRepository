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
    public float volume = 1f;
    public int currentLevel;
    public bool headphonesActive;

    #region Standard Unity Methods
    void Start()
    {
        Debug.Log("GameManager is running"); // delete this line after testing
    }

    void Update()
    {
        Debug.Log("GameManager is updating"); // delete this line after testing
    }
    #endregion
}
