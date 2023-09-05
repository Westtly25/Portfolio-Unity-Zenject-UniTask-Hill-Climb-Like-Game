using Zenject;
using Assets.Code.Runtime.Logic;
using Assets.Code.Runtime.Services.Saves;
using Assets.Code.Runtime.Services.Assets_Management;

namespace Assets.Code.Runtime.Services.Bootstrap
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FileHandler>()
                .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<SaveLoadService>()
                .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<AssetProvider>()
                .FromNew().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<BootstrapFlow>()
                .FromNew().AsSingle().NonLazy();
        }
    }
}