using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class PauseWindow : Window
    {
        [SerializeField]
        private Button continueButton;

        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private Button exitButton;

        private IWindowsHandler windowsHandler;

        public override void Initialize()
        {
            windowsHandler = diContainer.Resolve<IWindowsHandler>();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public override void Subscribe()
        {
            continueButton.onClick.AddListener(Continue);
            restartButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(Exit);
        }
        public override void UnSubscribe()
        {
            continueButton.onClick.AddListener(Continue);
            restartButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(Exit);
        }

        private void Continue()
        {
            windowsHandler.Pop();
        }

        private async void Restart()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            await Task.Delay(TimeSpan.FromSeconds(2));
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
        }

        private async void Exit()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            await Task.Delay(TimeSpan.FromSeconds(2));
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        }
    }
}