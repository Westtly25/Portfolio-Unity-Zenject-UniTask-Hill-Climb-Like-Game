using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Assets.Code.Runtime.Services.Assets_Management
{
    public sealed class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> completedCache = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> handles = new();
        public readonly Dictionary<string, SceneInstance> cachedScenes = new();

        public AssetProvider() =>
            Addressables.InitializeAsync();

        public async Task LoadSceneAsync(string adress, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(adress, loadSceneMode, false);

            var scene = await handle.Task;
            completedCache.Add(adress, handle);
            scene.ActivateAsync();
        }

        public async Task UnloadSceneAsync(string adress)
        {
            if (cachedScenes.TryGetValue(adress, out SceneInstance handle))
            {
                Addressables.UnloadSceneAsync(handle);
                completedCache.Remove(adress);
            }

            await Task.Yield();
        }

        public async Task<T> LoadAsync<T>(AssetReference assetReference) where T : class
        {
            if (completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithCacheOnComplete(
                Addressables.LoadAssetAsync<T>(assetReference),
                cacheKey: assetReference.AssetGUID);
        }

        public async Task<T> LoadAsync<T>(string adress) where T : class
        {
            if (completedCache.TryGetValue(adress, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunWithCacheOnComplete(
                Addressables.LoadAssetAsync<T>(adress),
                cacheKey: adress);
        }

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in handles.Values)
                foreach (AsyncOperationHandle handle in resourceHandles)
                    Addressables.Release(handle);

            completedCache.Clear();
            handles.Clear();
            cachedScenes.Clear();
        }

        private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
        {
            handle.Completed += completeHandle =>
                                completedCache[cacheKey] = completeHandle;

            AddHandle(cacheKey, handle);

            return await handle.Task;
        }

        private void AddHandle<T>(string cacheKey, AsyncOperationHandle<T> handle) where T : class
        {
            if (!handles.TryGetValue(cacheKey, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                handles[cacheKey] = resourceHandles;

                resourceHandles.Add(handle);
            }
        }
    }
}