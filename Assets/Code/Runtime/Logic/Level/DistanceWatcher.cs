using System;
using Zenject;
using UnityEngine;
using Assets.Code.Runtime.Utilities;
using Assets.Code.Runtime.Logic.Character;

namespace Assets.Code.Runtime.Logic.Level
{
    public class DistanceWatcher : ITickable
    {
        [Header("Injected Components")]
        private Vehicle player;
        private readonly LevelData levelData;
        private readonly DiContainer diContainer;

        [Inject]
        public DistanceWatcher(LevelData levelData, DiContainer diContainer)
        {
            this.levelData = levelData;
            this.diContainer = diContainer;
        }

        public void Tick()
        {
            if (player == null)
                ResolveTarget();

            Vector3 playerPos = player.transform.position;

            float distance = DistanceBetween(playerPos);
        }

        private float DistanceBetween(Vector2 playerPos) =>
            DataExtensions.SqrMagnitudeTo(playerPos, levelData.FinishPosition);

        private void ResolveTarget() =>
            player = diContainer.TryResolve<Vehicle>();
    }
}
