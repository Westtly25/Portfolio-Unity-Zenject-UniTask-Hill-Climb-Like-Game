using Zenject;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class SettingsWindow : Window
    {
        [SerializeField]
        private Slider mainVolume;

        [SerializeField]
        private Slider musicVolume;

        [SerializeField]
        private Slider sfxVolume;


        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        public override void Initialize()
        {
        }

        public override void Subscribe()
        {
        }

        public override void UnSubscribe()
        {
        }
    }
}