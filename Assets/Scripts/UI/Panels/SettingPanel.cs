using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingPanel : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private PausePanel _pausePanel;

    [Header("Button")]
    [SerializeField] private Button _closePanelButton;

    private SoundManager _soundManager;

    [Inject]
    private void Construct(SoundManager soundManager)
    {
        _soundManager = soundManager;
    }


    private void Start()
    {
        _closePanelButton.onClick.AddListener(ExitOptionsPanel);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _closePanelButton.onClick.RemoveListener(ExitOptionsPanel);
    }

    private void ExitOptionsPanel()
    {
        _soundManager.PlayClickSound();
        gameObject.SetActive(false);
        _pausePanel.gameObject.SetActive(true);
    }
}