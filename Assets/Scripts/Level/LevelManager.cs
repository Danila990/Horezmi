using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action OnStartGame;
    public event Action OnGameOver;

    public bool IsPlayGame => _isPlayGame;

    private bool _isPlayGame = false;

    public void StartGame()
    {
        print("start");
        PlayGame();
        OnStartGame?.Invoke();
    }

    public void GameOver()
    {
        StopGame();
        OnGameOver?.Invoke();
    }

    public void PlayGame() => _isPlayGame = true;

    public void StopGame() => _isPlayGame = false;
}