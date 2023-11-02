using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private UIPanel[] _uiPanels;

    private Dictionary<UIPanelName, GameObject> _panels = new Dictionary<UIPanelName, GameObject>();
    private LevelManager _levelManager;
    private SoundManager _soundManager;

    [Inject]
    private void Construct(SoundManager soundManager, LevelManager levelManager)
    {
        _soundManager = soundManager;
        _levelManager = levelManager;

        _levelManager.OnGameOver += OpenGameOverPanel;
    }

    private void Awake()
    {
        foreach (UIPanel panel in _uiPanels)
            _panels.Add(panel.Name, panel.PanelGameObject);

        ActivateNeedPanel(UIPanelName.Game);
    }

    private void OnDestroy()
    {
        _levelManager.OnGameOver -= OpenGameOverPanel;
    }

    public void ActivateNeedPanel(UIPanelName name)
    {
        foreach(var panel in _panels)
        {
            if(panel.Key == name)
            {
                panel.Value.SetActive(true);
                continue;
            }

            panel.Value.SetActive(false);
        }
    }

    public void SoundClick()
    {
        _soundManager.PlayClickSound();
    }

    public void RestartButton()
    {
        ActivateNeedPanel(UIPanelName.Game);
        YandexGame.FullscreenShow();
        _levelManager.RestartGame();
    }

    public void LoadHome()
    {
        SoundClick();
        SceneManager.LoadScene(0);
    }

    private void OpenGameOverPanel()
    {
        ActivateNeedPanel(UIPanelName.GameOver);
    }

}

[System.Serializable]
public class UIPanel
{
    public GameObject PanelGameObject;
    public UIPanelName Name;
}

public enum UIPanelName
{
    Game, Pause, GameOver, Setting, Exit
}