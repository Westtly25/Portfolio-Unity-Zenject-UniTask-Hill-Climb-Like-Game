using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Code.Runtime.Logic.Character;

namespace Assets.Code.Runtime.Services.Windows
{
    public sealed class GameplayWindow : Window
    {
        [SerializeField]
        private Button breaksButton;

        [SerializeField]
        private Button gasButton;

        [SerializeField]
        private Button pauseButton;

        private IWindowsHandler windowsHandler;
        private Vehicle playerController;

        public override void Initialize()
        {
            windowsHandler = diContainer.Resolve<IWindowsHandler>();
            playerController = diContainer.TryResolve<Vehicle>();
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
            pauseButton?.onClick.AddListener(Pause);

            EventTrigger eventTrigger = gasButton.GetComponent<EventTrigger>();

            EventTrigger.Entry entryPointerUp = new();
            entryPointerUp.eventID = EventTriggerType.PointerUp;
            entryPointerUp.callback.AddListener((data) => { GasDisable((PointerEventData)data); });
            eventTrigger.triggers.Add(entryPointerUp);

            EventTrigger.Entry entryPointerDown = new();
            entryPointerDown.eventID = EventTriggerType.PointerDown;
            entryPointerDown.callback.AddListener((data) => { GasEnable((PointerEventData)data); });
            eventTrigger.triggers.Add(entryPointerDown);

            EventTrigger eventTriggerBreak = breaksButton.GetComponent<EventTrigger>();

            EventTrigger.Entry entryPointerUpBreak = new();
            entryPointerUpBreak.eventID = EventTriggerType.PointerUp;
            entryPointerUpBreak.callback.AddListener((data) => { BreakDisable((PointerEventData)data); });
            eventTriggerBreak.triggers.Add(entryPointerUpBreak);

            EventTrigger.Entry entryPointerDownBreak = new();
            entryPointerDownBreak.eventID = EventTriggerType.PointerDown;
            entryPointerDownBreak.callback.AddListener((data) => { BreakEnable((PointerEventData)data); });
            eventTriggerBreak.triggers.Add(entryPointerDownBreak);
        }

        public override void UnSubscribe()
        {
            pauseButton?.onClick.AddListener(Pause);
        }

        private void GasEnable(PointerEventData eventData)
        {
            ResolvePlayerController();

            playerController.ShouldMove(true);
        }

        private void GasDisable(PointerEventData pointerEventData) =>
            playerController.ShouldMove(false);

        private void BreakEnable(PointerEventData eventData)
        {
            ResolvePlayerController();

            playerController.ShouldBreak(true);
        }

        private void BreakDisable(PointerEventData eventData) =>
            playerController.ShouldBreak(false);

        private void Pause() =>
            windowsHandler.ShowPopUp<PauseWindow>();

        private void ResolvePlayerController()
        {
            if (playerController == null)
                playerController = diContainer.Resolve<Vehicle>();
        }
    }
}