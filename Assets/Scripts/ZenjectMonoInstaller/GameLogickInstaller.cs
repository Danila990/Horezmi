using UnityEngine;
using Zenject;

public class GameLogickInstaller : MonoInstaller
{
    [SerializeField] private NumberGenerator _numberGenerator;
    [SerializeField] private LevelSetting _levelSetting;
    [SerializeField] private NumberSelect _numberSelect;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private Timerlevel _timerlevel;
    [SerializeField] private ScoreLevel _scorelevel;
    [SerializeField] private GameMenuController _gameMenuController;


    public override void InstallBindings()
    {
        Container.Bind<NumberGenerator>().FromInstance(_numberGenerator).AsSingle().NonLazy();

        Container.Bind<LevelSetting>().FromInstance(_levelSetting).AsSingle().NonLazy();

        Container.Bind<NumberSelect>().FromInstance(_numberSelect).AsSingle().NonLazy();

        Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle().NonLazy();

        Container.Bind<Timerlevel>().FromInstance(_timerlevel).AsSingle().NonLazy();

        Container.Bind<ScoreLevel>().FromInstance(_scorelevel).AsSingle().NonLazy();

        Container.Bind<GameMenuController>().FromInstance(_gameMenuController).AsSingle().NonLazy();
    }
}
