using Zenject;
using UnityEngine;
using Assets.Code.Runtime.Services.Windows;

namespace Assets.Code.Runtime.Services.Meta
{
    public sealed class MetaInstaller : MonoInstaller
    {
        [SerializeField]
        private MenuWindow menuWindow;

        [SerializeField]
        private QuiteWindow quiteWindow;

        public override void InstallBindings()
        {
            Container.Bind<Window>().To<MenuWindow>()
                .FromInstance(menuWindow).AsSingle().NonLazy();

            Container.Bind<Window>().To<QuiteWindow>()
                .FromInstance(quiteWindow).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<WindowsHandler>()
                .FromNew().AsSingle().WithArguments(new Window[] { menuWindow, quiteWindow});

            Container.BindInterfacesAndSelfTo<MetaFlow>()
                .FromNew().AsSingle();
        }
    }
}