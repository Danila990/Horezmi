using UnityEngine;
using Zenject;

public class GameState : MonoBehaviour
{
    private LevelManager _levelManager;

    [Inject]
    private void Construct(LevelManager levelManager)
    {
        _levelManager = levelManager;
        _levelManager.StopGame();
    }

    private void OnEnable()
    {
        _levelManager.PlayGame();
    }

    private void OnDisable()
    {
        _levelManager.StopGame();
    }
}
