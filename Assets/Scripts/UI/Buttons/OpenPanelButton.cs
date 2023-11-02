using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenPanelButton : MonoBehaviour
{
    [SerializeField] private UIPanelName _panelName;

    private GameUIController _gameUIController;

    [Inject]
    private void Construct(GameUIController gameUIController)
    {
        _gameUIController = gameUIController;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick
            .AddListener(ClickButton);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick
            .RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        _gameUIController.ActivateNeedPanel(_panelName);
        _gameUIController.SoundClick();
    }
}
