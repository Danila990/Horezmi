using UnityEngine;
using Zenject;

public class SoundManagerInstaller : MonoInstaller
{
    [SerializeField] private SoundManager _soundManagerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<SoundManager>().FromComponentInNewPrefab(_soundManagerPrefab).AsSingle().NonLazy();
    }
}
