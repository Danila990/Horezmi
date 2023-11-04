using UnityEngine;
using Zenject;

public class PrefabsInstaller : MonoInstaller
{
    [SerializeField] private Timerlevel _timerLevelPrefab;
    [SerializeField] private ScoreLevel _scoreLevelPrefab;
    [SerializeField] private LevelManager _levelManagerPrefab;
    [SerializeField] private LevelSetting _levelSettingPrefab;

    public override void InstallBindings()
    {
        Container.Bind<LevelManager>().FromComponentInNewPrefab(_levelManagerPrefab).AsSingle().NonLazy();

        Container.Bind<LevelSetting>().FromComponentInNewPrefab(_levelSettingPrefab).AsSingle().NonLazy();

        Container.Bind<Timerlevel>().FromComponentInNewPrefab(_timerLevelPrefab).AsSingle().NonLazy();

        Container.Bind<ScoreLevel>().FromComponentInNewPrefab(_scoreLevelPrefab).AsSingle().NonLazy();
    }
}
