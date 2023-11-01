using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gamePanelCanvasGroup;
    [SerializeField] private GameObject _pausePanel;

    private SoundManager _soundManager;

    [Inject]
    private void Construct(SoundManager soundManager)
    {
        _soundManager = soundManager;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ClickButton);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        _gamePanelCanvasGroup.alpha = 0;
        _soundManager.PlayClickSound();
        _pausePanel.gameObject.SetActive(true);
    }
}
