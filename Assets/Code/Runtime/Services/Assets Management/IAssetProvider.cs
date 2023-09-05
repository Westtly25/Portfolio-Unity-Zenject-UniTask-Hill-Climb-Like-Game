using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Assets.Code.Runtime.Services.Assets_Management
{
    public interface IAssetProvider
    {
        Task LoadSceneAsync(string adress, LoadSceneMode loadSceneMode = LoadSceneMode.Additive);
        Task<T> LoadAsync<T>(AssetReference assetReference) where T : class;
        Task<T> LoadAsync<T>(string adress) where T : class;
        void CleanUp();
        Task UnloadSceneAsync(string adress);
    }
}