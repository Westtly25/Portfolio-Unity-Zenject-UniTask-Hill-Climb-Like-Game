namespace Assets.Code.Runtime.Services.Pause
{
    public interface IPauseHandler
    {
        bool IsPaused { get; }

        void SetPause(bool isPaused);
    }
}