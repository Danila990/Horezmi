using System;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    public event Action OnRestartGame;
    public event Action OnGameOver;
    public event Action OnRevivalGame;

    public bool IsPlayGame => _isPlayGame;

    private bool _isPlayGame = false;
    private LevelSetting _levelSetting;

    [Inject]
    private void Construct(LevelSetting levelSetting)
    {
        _levelSetting = levelSetting;
    }

    private void Start() => RestartGame();

    public void RestartGame()
    {
        PlayGame();
        _levelSetting.RestartSetting();
        OnRestartGame?.Invoke();
    }

    public void GameOver()
    {
        StopGame();
        OnGameOver?.Invoke();
    }

    public void RevivalGame()
    {
        PlayGame();
        OnRevivalGame?.Invoke();
    }

    public void PlayGame() => _isPlayGame = true;

    public void StopGame() => _isPlayGame = false;
}