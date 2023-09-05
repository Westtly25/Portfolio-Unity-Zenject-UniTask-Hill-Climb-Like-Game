using Zenject;
using System.Threading.Tasks;
using Assets.Code.Runtime.Logic.Level;
using Assets.Code.Runtime.Services.Pause;
using Assets.Code.Runtime.Logic.Character;
using Assets.Code.Runtime.Services.Windows;

namespace Assets.Code.Runtime.Services.Gameplay
{
    public sealed class GameplayFlow : IInitializable
    {
        private IPauseHandler pauseHandler;
        private IWindowsHandler windowsHandler;
        private LevelData levelData;
        private IVechicleFactory vechicleFactory;

        [Inject]
        public GameplayFlow(IPauseHandler pauseHandler,
                            IWindowsHandler windowsHandler,
                            LevelData levelData,
                            IVechicleFactory vechicleFactory)
        {
            this.pauseHandler = pauseHandler;
            this.windowsHandler = windowsHandler;
            this.levelData = levelData;
            this.vechicleFactory = vechicleFactory;
        }

        public async void Initialize()
        {
            windowsHandler.Initialize();
            await CreatePlayer();

            levelData.FinishPoint.Finished += OnPlayerFinished;
            windowsHandler.Show<GameplayWindow>();
        }

        private async Task CreatePlayer()
        {
            Vehicle player = await vechicleFactory.Create();
            player.transform.position = levelData.SpawnPosition;
        }

        private void OnPlayerFinished()
        {
            levelData.FinishPoint.Finished -= OnPlayerFinished;
            windowsHandler.Show<CompleteWindow>();
        }
    }
}