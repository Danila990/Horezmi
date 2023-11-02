using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private NumberGenerator _numberGenerator;
    [SerializeField] private GameUIController _uiController;

    public override void InstallBindings()
    {
        Container.Bind<NumberGenerator>().FromInstance(_numberGenerator).AsSingle().NonLazy();
        Container.Bind<GameUIController>().FromInstance(_uiController).AsSingle().NonLazy();
    }
}
