using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private NumberGenerator _numberGenerator;

    public override void InstallBindings()
    {
        Container.Bind<NumberGenerator>().FromInstance(_numberGenerator).AsSingle().NonLazy();
    }
}
