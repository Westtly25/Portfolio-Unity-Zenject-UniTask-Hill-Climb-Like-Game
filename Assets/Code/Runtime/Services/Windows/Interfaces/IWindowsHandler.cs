namespace Assets.Code.Runtime.Services.Windows
{
    public interface IWindowsHandler
    {
        void Show<T>() where T : Window;
        void ShowPopUp<T>() where T : Window;
        void Pop();
        void Initialize();
    }
}