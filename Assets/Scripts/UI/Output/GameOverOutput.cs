using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class GameOverOutput : MonoBehaviour
{
    public const string NAME_LEADER_BOARD = "TheBestPlayers";

    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _recordText;

    private ScoreLevel _scorelevel;

    [Inject]
    private void Construct(ScoreLevel scoreLevel)
    {
        _scorelevel = scoreLevel;
    }

    private void OnEnable()
    {
        OutputRecord();
        OutputScore();
    }

    private void OutputRecord()
    {
        if (YandexGame.savesData.ScoreRecord < _scorelevel.CurrentScore)
        {
            if (YandexGame.savesData.language == "ru")
                _recordText.text = $"����� ������: {_scorelevel.CurrentScore}";
            else
                _recordText.text = $"New Record: {_scorelevel.CurrentScore}";

            YandexGame.savesData.ScoreRecord = _scorelevel.CurrentScore;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores(NAME_LEADER_BOARD, _scorelevel.CurrentScore);
            return;
        }

        if (YandexGame.savesData.language == "ru")
            _recordText.text = $"������: {YandexGame.savesData.ScoreRecord}";
        else
            _recordText.text = $"Record: {YandexGame.savesData.ScoreRecord}";
    }

    private void OutputScore()
    {
        if (YandexGame.savesData.language == "ru")
            _currentScoreText.text = $"����: {_scorelevel.CurrentScore}";
        else
            _currentScoreText.text = $"Score: {_scorelevel.CurrentScore}";
    }
}
