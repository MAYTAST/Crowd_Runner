using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public enum GameState {Menu,Game,levelComplete,GameOver};
    public static GameManager _instance;
    public static Action<GameState> onStateChanged;
    private GameState _gameState;
    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
            _instance = this;
    }
    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
        onStateChanged?.Invoke(gameState);
    }
    public bool isGameState()
    {
        return _gameState == GameState.Game;
    }
}
