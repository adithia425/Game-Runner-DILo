using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public GameState state;

    public static event Action<GameState> OnGameStateChange;

    private void Awake()
    {
        gameManager = this;
    }
    private void Start()
    {
        UpdateGameState(GameState.OPENING);
    }


    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (state)
        {
            case GameState.OPENING:
                break;
            case GameState.MAIN_MENU:
                break;
            case GameState.GAME_RUN:
                break;
            case GameState.GAME_FIGHT:
                break;
            case GameState.PAUSE:
                break;
            case GameState.FINISH:
                break;
            case GameState.END:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }


    public enum GameState
    {
        OPENING,
        MAIN_MENU,
        GAME_RUN,
        GAME_FIGHT,
        PAUSE,
        FINISH,
        END
    }
}
