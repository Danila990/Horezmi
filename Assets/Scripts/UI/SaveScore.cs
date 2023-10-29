using TMPro;
using UnityEngine;
using YG;

public class SaveScore : MonoBehaviour
{
    public const string NAME_LEADER_BOARD = "TheBestPlayers";

    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private ScoreLevel _scoreLevel;

    private void OnEnable()
    {
       OutputRecord();
       OutputCurrentScore();
    }

    private void OutputRecord()
    {
        if (YandexGame.savesData.ScoreRecord < _scoreLevel.CurrentScore)
        {
            if (YandexGame.savesData.language == "ru")
                _recordText.text = $"Новый Рекорд: {_scoreLevel.CurrentScore}";
            else
                _recordText.text = $"New Record {_scoreLevel.CurrentScore}";

            YandexGame.savesData.ScoreRecord = _scoreLevel.CurrentScore;
            YandexGame.NewLeaderboardScores(NAME_LEADER_BOARD, _scoreLevel.CurrentScore);
            return;
        }

        if (YandexGame.savesData.language == "ru")
            _recordText.text = $"Рекорд: {_scoreLevel.CurrentScore}";
        else
            _recordText.text = $"Record {_scoreLevel.CurrentScore}";
    }

    private void OutputCurrentScore()
    {
        _currentScoreText.text = $"{_currentScoreText.text} {_scoreLevel.CurrentScore}";
    }
}
