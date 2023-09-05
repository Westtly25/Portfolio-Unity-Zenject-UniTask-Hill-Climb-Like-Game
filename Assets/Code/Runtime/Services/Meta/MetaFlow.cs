using Zenject;
using Assets.Code.Runtime.Services.Windows;

namespace Assets.Code.Runtime.Services.Meta
{
    public sealed class MetaFlow : IInitializable
    {
        private IWindowsHandler windowsHandler;

        [Inject]
        public void Construct(IWindowsHandler windowsHandler) =>
            this.windowsHandler = windowsHandler;


        public void Initialize()
        {
            windowsHandler.Initialize();
            windowsHandler.Show<MenuWindow>();
        }
    }
}