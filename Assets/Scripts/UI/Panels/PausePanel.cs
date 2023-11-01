using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class PausePanel : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _exitPanel;
    [SerializeField] private CanvasGroup _gamePanelCanvasGroup;

    [Header("Button")]
    [SerializeField] private Button _closePanelButton;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _loadHomeButton;

    private SoundManager _soundManager;
    private LevelManager _levelManager;

    [Inject]
    private void Construct(SoundManager soundManager,LevelManager levelManager)
    {
        _soundManager = soundManager;
        _levelManager = levelManager;
    }

    private void Start()
    {
        _closePanelButton.onClick.AddListener(ExitPausePanel);
        _restartGameButton.onClick.AddListener(RestartButton);
        _settingButton.onClick.AddListener(OpenSettingPanel);
        _loadHomeButton.onClick.AddListener(OpenExitPanel);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _closePanelButton.onClick.RemoveListener(ExitPausePanel);
        _restartGameButton.onClick.RemoveListener(RestartButton);
        _settingButton.onClick.RemoveListener(OpenSettingPanel);
        _loadHomeButton.onClick.RemoveListener(OpenExitPanel);
    }

    private void OpenExitPanel()
    {
        _soundManager.PlayClickSound();
        gameObject.SetActive(false);
        _exitPanel.gameObject.SetActive(true);
    }

    private void ExitPausePanel()
    {
        _soundManager.PlayClickSound();
        gameObject.SetActive(false) ;
        _gamePanelCanvasGroup.alpha = 1.0f;
        _levelManager.PlayGame();
    }

    private void RestartButton()
    {
        _gamePanelCanvasGroup.alpha = 1.0f;
        gameObject.SetActive(false);
        YandexGame.FullscreenShow();
        _levelManager.RestartGame();
    }

    private void OpenSettingPanel()
    {
        _soundManager.PlayClickSound();
        gameObject.SetActive(false);
        _settingPanel.gameObject.SetActive(true);
    }
}
