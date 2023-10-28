using TMPro;
using UnityEngine;

public class ScoreLevel : MonoBehaviour
{
    public int CurrentScore => _currentScore;

    [SerializeField] private TMP_Text _gameScoreText;

    private int _currentScore = 0;
    private NumberSelect _numberSelect;
    private LevelManager _levelManager;

    private void OnDestroy()
    {
        _levelManager.OnStartGame -= RestartScore;
        _numberSelect.OnSelectComplete -= UpdateScore;
    }

    public void Init(NumberSelect numberSelect, LevelManager levelManager)
    {
        _numberSelect = numberSelect;
        _levelManager = levelManager;

        _levelManager.OnStartGame += RestartScore;
        _numberSelect.OnSelectComplete += UpdateScore;
    }

    private void UpdateScore()
    {
        _currentScore++;
        OutputScore();
    }

    private void OutputScore()
    {
        _gameScoreText.text = _currentScore.ToString();
    }

    private void RestartScore()
    {
        _currentScore = 0;
        OutputScore();
    }
}
