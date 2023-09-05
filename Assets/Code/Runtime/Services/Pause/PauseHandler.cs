using System;

namespace Assets.Code.Runtime.Services.Pause
{
    public class PauseHandler : IPauseHandler
    {
        public bool IsPaused { get; private set; } = false;

        public void SetPause(bool isPaused)
        {
            IsPaused = isPaused;
        }
    }
}