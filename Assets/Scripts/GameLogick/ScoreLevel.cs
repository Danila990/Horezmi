using System;
using UnityEngine;
using Zenject;

public class ScoreLevel : MonoBehaviour
{
    public event Action<int> OnScoreChange;

    public int CurrentScore => _currentScore;

    private int _currentScore = 0;
    private NumberSelect _numberSelect;
    private LevelManager _levelManager;

    [Inject]
    private void Construct(NumberSelect numberSelect, LevelManager levelManager)
    {
        _numberSelect = numberSelect;
        _levelManager = levelManager;

        _levelManager.OnRestartGame += RestartGame;
        _numberSelect.OnSelectComplete += UpdateScore;
    }

    private void OnDestroy()
    {
        _levelManager.OnRestartGame -= RestartGame;
        _numberSelect.OnSelectComplete -= UpdateScore;
    }

    private void UpdateScore()
    {
        _currentScore++;
        OutputScore();
    }

    private void OutputScore() => OnScoreChange?.Invoke(_currentScore);

    private void RestartGame()
    {
        _currentScore = 0;
        OutputScore();
    }
}