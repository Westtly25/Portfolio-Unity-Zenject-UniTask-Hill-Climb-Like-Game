using Zenject;
using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Assets.Code.Runtime.Services.Saves;

namespace Assets.Code.Runtime.Services.Bootstrap
{
    public sealed class BootstrapFlow : IInitializable
    {
        private readonly ISaveLoadService saveLoadService;

        [Inject]
        public BootstrapFlow(ISaveLoadService saveLoadService)
        {
            this.saveLoadService = saveLoadService;
        }

        public void Initialize()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            Task[] tasks = new Task[]
            {
                saveLoadService.Load(),
            };

            Task handle = Task.WhenAll(tasks);
            handle.Wait();

            if (handle.IsCompletedSuccessfully)
            {
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
            }
            else if (handle.IsFaulted) { Debug.Log("Bootstrap Tasks Failed"); }
        }
    }
}