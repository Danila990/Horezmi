using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private NumberGenerator _numberGenerator;
    [SerializeField] private LevelSetting _levelSetting;
    [SerializeField] private NumberSelect _numberSelect;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private Timerlevel _timerlevel;
    [SerializeField] private ScoreLevel _scorelevel;
    [SerializeField] private GameMenuController _gameMenuController;

    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = FindAnyObjectByType<SoundManager>();
        _gameMenuController.Init(_soundManager, _levelManager);
        _levelSetting.Init(_levelManager, _numberSelect);
        _numberGenerator.Init(_levelSetting, _levelManager);
        _numberSelect.Init( _levelManager, _numberGenerator, _soundManager, _timerlevel);
        _timerlevel.Init(_levelManager, _numberSelect);
        _scorelevel.Init(_numberSelect, _levelManager);

        _levelManager.StartGame();
    }
}