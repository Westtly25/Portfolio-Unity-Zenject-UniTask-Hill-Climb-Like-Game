using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using Assets.Code.Runtime.Shared;
using Assets.Code.Runtime.Services.Assets_Management;

namespace Assets.Code.Runtime.Logic.Character
{
    public class VechicleFactory : IVechicleFactory
    {
        private readonly DiContainer diContainer;
        private readonly IAssetProvider assetProvider;

        [Inject]
        public VechicleFactory(DiContainer diContainer, IAssetProvider assetProvider)
        {
            this.diContainer = diContainer;
            this.assetProvider = assetProvider;
        }

        public async Task<Vehicle> Create()
        {
            GameObject loaded = await assetProvider.LoadAsync<GameObject>(SharedData.PlayerAdresses.Player);
            Vehicle instantiated = diContainer.InstantiatePrefabForComponent<Vehicle>(loaded);
            diContainer.BindInterfacesAndSelfTo<Vehicle>().FromInstance(instantiated).AsCached().NonLazy();

            return instantiated;
        }
    }
}