using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RevivalButton : MonoBehaviour
{
    private bool _isReadyRevivalGame = true;
    private GameUIController _gameUIController;
    private LevelManager _levelManager;

    [Inject]
    private void Construct(GameUIController gameUIController, LevelManager levelManager)
    {
        _gameUIController = gameUIController;
        _levelManager = levelManager;

        _levelManager.OnRestartGame += RestartGame;
    }

    private void OnEnable()
    {
        if(_isReadyRevivalGame)
            GetComponent<Button>().interactable = true;
        else GetComponent<Button>().interactable = false;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickButton);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickButton);
        _levelManager.OnRestartGame -= RestartGame;
    }

    private void ClickButton()
    {
        _isReadyRevivalGame = false;
        _gameUIController.RevivalButton();
    }

    private void RestartGame()
    {
        _isReadyRevivalGame = true;
    }
}