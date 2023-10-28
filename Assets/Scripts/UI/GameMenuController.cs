using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameMenuController : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _exitMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _pauseMenu;
    //[SerializeField] private GameObject _optionsMenu;

    [Header("Button")]

    [SerializeField] private Button _openExitMenuButton;
    [SerializeField] private Button _closeExitMenuButton;
    [SerializeField] private Button _loadMenuExitButton;

    [SerializeField] private Button _loadMenuGameOverButton;
    [SerializeField] private Button _restartGameOverButton;

    [SerializeField] private Button _openPauseMenuButton;
    [SerializeField] private Button _closePauseMenu;

    /*[SerializeField] private Button _openOptionsMenu;
    [SerializeField] private Button _exitOptionsButton;*/

    private SoundManager _soundManager;
    private LevelManager _levelManager;

    private void OnDestroy()
    {
        _levelManager.OnGameOver -= OpenGameOverMenu;

        _loadMenuExitButton.onClick.RemoveListener(LoadMenu);
        _loadMenuGameOverButton.onClick.RemoveListener(LoadMenu);
        _openPauseMenuButton.onClick.RemoveListener(OpenExitMenu);
        _closeExitMenuButton.onClick.RemoveListener(CloseExitMenu);
        _restartGameOverButton.onClick.RemoveListener(RestartGame);
        _closePauseMenu.onClick.RemoveListener(ClosePauseMenu);
        /*_openOptionsMenu.onClick.RemoveListener(OpenOptionsMenu);
        _exitOptionsButton.onClick.RemoveListener(CloseOptionsMenu);*/
        _openExitMenuButton.onClick.RemoveListener(OpenExitMenu);
    }

    public void Init(SoundManager soundManager, LevelManager levelManager)
    {
        _soundManager = soundManager;
        _levelManager = levelManager;

        _exitMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        //_optionsMenu.SetActive(false);
        _gameMenu.SetActive(true);

        _levelManager.OnGameOver += OpenGameOverMenu;

        SetupButtons();
    }

    private void SetupButtons()
    {
        _loadMenuExitButton.onClick.AddListener(LoadMenu);
        _loadMenuGameOverButton.onClick.AddListener(LoadMenu);
        _openPauseMenuButton.onClick.AddListener(OpenPauseMenu);
        _closeExitMenuButton.onClick.AddListener(CloseExitMenu);
        _restartGameOverButton.onClick.AddListener(RestartGame);
        _closePauseMenu.onClick.AddListener(ClosePauseMenu);
       /* _openOptionsMenu.onClick.AddListener(OpenOptionsMenu);
        _exitOptionsButton.onClick.AddListener(CloseOptionsMenu);*/
        _openExitMenuButton.onClick.AddListener(OpenExitMenu);
    }

    private void RestartGame()
    {
        DefaultSetupButton(_gameOverMenu, _gameMenu);
        YandexGame.FullscreenShow();
        _levelManager.StartGame();
    }

    private void OpenPauseMenu()
    {
        _gameMenu.GetComponent<CanvasGroup>().enabled = true;
        _pauseMenu.SetActive(true);
        _levelManager.StopGame();
        _soundManager.PlayClickSound();
    }

    private void ClosePauseMenu() 
    {
        _gameMenu.GetComponent<CanvasGroup>().enabled = false;
        _pauseMenu.SetActive(false);
        _levelManager.PlayGame();
        _soundManager.PlayClickSound();
    }

    /*private void OpenOptionsMenu()
    {
        DefaultSetupButton(_pauseMenu, _optionsMenu);
    }

    private void CloseOptionsMenu()
    {
        DefaultSetupButton(_optionsMenu, _pauseMenu);
    }*/

    private void OpenExitMenu()
    {
        DefaultSetupButton(_pauseMenu, _exitMenu);
    }

    private void CloseExitMenu()
    {
        DefaultSetupButton(_exitMenu, _pauseMenu);
    }

    private void LoadMenu()
    {
        _soundManager.PlayClickSound();
        SceneManager.LoadSceneAsync(0);
    }

    private void DefaultSetupButton(GameObject deactivate, GameObject activate)
    {
        _soundManager.PlayClickSound();
        deactivate.SetActive(false);
        activate.SetActive(true);
    }

    private void OpenGameOverMenu()
    {
        _gameMenu.SetActive(false);
        _gameOverMenu.SetActive(true);
    }
}
