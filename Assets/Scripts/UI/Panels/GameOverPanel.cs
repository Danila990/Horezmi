using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

public class GameOverPanel : MonoBehaviour
{
    public const string NAME_LEADER_BOARD = "TheBestPlayers";
    [Header("panel")]
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private CanvasGroup _gamePanelCanvasGroup;

    [Header("Button")]
    [SerializeField] private Button _loadHomeButton;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _recordText;

    private SoundManager _soundManager;
    private LevelManager _levelManager;
    private ScoreLevel _scorelevel;

    [Inject]
    private void Construct(SoundManager soundManager,LevelManager levelManager, ScoreLevel scoreLevel)
    {
        _scorelevel = scoreLevel;
        _soundManager = soundManager;
        _levelManager = levelManager;

        _levelManager.OnGameOver += OpenGameOverPanel;
    }

    private void OnEnable()
    {
        OutputRecord();
        OutputScore();
    }

    private void Start()
    {
        _loadHomeButton.onClick.AddListener(LoadHome);
        _restartGameButton.onClick.AddListener(RestartButton);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _loadHomeButton.onClick.RemoveListener(LoadHome);
        _restartGameButton.onClick.RemoveListener(RestartButton);

        _levelManager.OnGameOver -= OpenGameOverPanel;
    }

    private void OpenGameOverPanel()
    {
        _gamePanelCanvasGroup.alpha = 0f;
        gameObject.SetActive(true);
    }

    private void OutputRecord()
    {
        if (YandexGame.savesData.ScoreRecord < _scorelevel.CurrentScore)
        {
            if (YandexGame.savesData.language == "ru")
                _recordText.text = $"Новый Рекорд: {_scorelevel.CurrentScore}";
            else
                _recordText.text = $"New Record: {_scorelevel.CurrentScore}";

            YandexGame.savesData.ScoreRecord = _scorelevel.CurrentScore;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores(NAME_LEADER_BOARD, _scorelevel.CurrentScore);
            return;
        }

        if (YandexGame.savesData.language == "ru")
            _recordText.text = $"Рекорд: {YandexGame.savesData.ScoreRecord}";
        else
            _recordText.text = $"Record: {YandexGame.savesData.ScoreRecord}";
    }

    private void OutputScore()
    {
        if (YandexGame.savesData.language == "ru")
            _currentScoreText.text = $"Очки: {_scorelevel.CurrentScore}";
        else
            _currentScoreText.text = $"Score: {_scorelevel.CurrentScore}";
    }

    private void RestartButton()
    {
        gameObject.SetActive(false);
        _gamePanelCanvasGroup.alpha = 1.0f;
        YandexGame.FullscreenShow();
        _levelManager.RestartGame();
    }

    private void LoadHome()
    {
        _soundManager.PlayClickSound();
        SceneManager.LoadScene(0);
    }
}
