using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class CompleteWindow : Window
    {
        [SerializeField]
        public Button restartButton;

        [SerializeField]
        private Button exiteButton;

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
            restartButton?.onClick.AddListener(Restart);
            exiteButton?.onClick.AddListener(Exite);
        }

        public override void UnSubscribe()
        {
            restartButton?.onClick.RemoveListener(Restart);
            exiteButton?.onClick.RemoveListener(Exite);
        }

        private async void Restart()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            await Task.Delay(TimeSpan.FromSeconds(2));
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
        }

        private async void Exite()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            await Task.Delay(TimeSpan.FromSeconds(2));
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        }
    }
}
