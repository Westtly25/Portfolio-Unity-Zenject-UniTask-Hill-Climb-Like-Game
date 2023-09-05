using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using Assets.Code.Runtime.Services.Assets_Management;

namespace Assets.Code.Runtime.Services.Windows
{
    public class WindowsFactory
    {
        private readonly DiContainer diContainer;
        private readonly IAssetProvider assetProvider;

        [Inject]
        public WindowsFactory(DiContainer diContainer, IAssetProvider assetProvider)
        {
            this.diContainer = diContainer;
            this.assetProvider = assetProvider;
        }

        public async Task<Window> Create(string address)
        {
            GameObject loaded = await assetProvider.LoadAsync<GameObject>(address);
            return diContainer.InstantiatePrefabForComponent<Window>(loaded);
        }
    }
}