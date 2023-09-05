using Zenject;
using UnityEngine;
using Assets.Code.Runtime.Logic.Level;
using Assets.Code.Runtime.Services.Pause;
using Assets.Code.Runtime.Services.Windows;
using Assets.Code.Runtime.Logic.Character;

namespace Assets.Code.Runtime.Services.Gameplay
{
    public sealed class GameplayInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelData levelData;

        [SerializeField]
        private GameplayWindow gameplayWindow;

        [SerializeField]
        private PauseWindow pauseWindow;

        [SerializeField]
        private CompleteWindow completeWindow;

        public override void InstallBindings()
        {
            Container.Bind<Window>().To<GameplayWindow>()
                .FromInstance(gameplayWindow).AsSingle().NonLazy();

            Container.Bind<Window>().To<PauseWindow>()
                .FromInstance(pauseWindow).AsSingle().NonLazy();

            Container.Bind<Window>().To<CompleteWindow>()
                .FromInstance(completeWindow).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<WindowsHandler>()
               .FromNew().AsSingle().WithArguments(new Window[] { gameplayWindow, pauseWindow, completeWindow });

            Container.BindInterfacesAndSelfTo<LevelData>()
                 .FromInstance(levelData).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PauseHandler>()
                .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<VechicleFactory>()
                .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GameplayFlow>()
                .FromNew().AsSingle();
        }
    }
}