using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using YG;

public class SaveScore : MonoBehaviour
{
    public const string NAME_LEADER_BOARD = "TheBestPlayers";

    [SerializeField] private LeaderboardYG _leaderboardYG;
    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private ScoreLevel _scoreLevel;

    private string _record;

    private void OnEnable()
    {
        if (_record == null)
            _record = _recordText.text;
       OutputRecord();
       OutputCurrentScore();
    }

    private void OutputRecord()
    {
        if (YandexGame.savesData.ScoreRecord < _scoreLevel.CurrentScore)
        {
            if (LocalizationSettings.SelectedLocale.ToString() == "ru")
                _recordText.text = $"Новый {_recordText.text} {_scoreLevel.CurrentScore}";
            else
                _recordText.text = $"New {_recordText.text} {_scoreLevel.CurrentScore}";

            YandexGame.savesData.ScoreRecord = _scoreLevel.CurrentScore;
            YandexGame.NewLeaderboardScores(NAME_LEADER_BOARD, _scoreLevel.CurrentScore);
            return;
        }

        _recordText.text = $"{_record} {YandexGame.savesData.ScoreRecord}";
    }

    private void OutputCurrentScore()
    {
        _currentScoreText.text = $"{_currentScoreText.text} {_scoreLevel.CurrentScore}";
    }
}
