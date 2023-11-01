using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class ExitPanel : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private PausePanel _pausePanel;

    [Header("Button")]
    [SerializeField] private Button _closePanelPanel;
    [SerializeField] private Button _lodeHomeButton;

    private SoundManager _soundManager;

    [Inject]
    private void Construct(SoundManager soundManager)
    {
        _soundManager = soundManager;
    }


    private void Start()
    {
        _closePanelPanel.onClick.AddListener(ExitOptionsPanel);
        _lodeHomeButton.onClick.AddListener(LoadHome);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _closePanelPanel.onClick.RemoveListener(ExitOptionsPanel);
        _lodeHomeButton.onClick.RemoveListener(LoadHome);
    }

    private void LoadHome()
    {
        _soundManager.PlayClickSound();
        SceneManager.LoadScene(0);
    }

    private void ExitOptionsPanel()
    {
        _soundManager.PlayClickSound();
        gameObject.SetActive(false);
        _pausePanel.gameObject.SetActive(true);
    }
}
