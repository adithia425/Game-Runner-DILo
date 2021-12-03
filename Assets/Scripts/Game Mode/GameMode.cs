using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public ModeRun modeRun;

    private void Awake()
    {
        GameManager.OnGameStateChange += GameManagerOnGameStateChange;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChange;
    }
    private void GameManagerOnGameStateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.GAME_RUN)
            ModeRunActive();
        else if (state == GameManager.GameState.GAME_FIGHT)
            ModeFightActive();
    }

    public bool t;
    void Update()
    {
        if (t)
            GameManager.gameManager.UpdateGameState(GameManager.GameState.GAME_RUN);
        else
            GameManager.gameManager.UpdateGameState(GameManager.GameState.GAME_FIGHT);
    }

    public void ModeRunActive()
    {
        CameraControl.camera.ZoomOut();
        modeRun.ModeRunOn();
        PlayerControl.insPlayerControl.ModeRun();
    }
    public void ModeFightActive()
    {
        modeRun.ModeRunOff();
        CameraControl.camera.ZoomIn();
        PlayerControl.insPlayerControl.ModeFight();
    }
}
