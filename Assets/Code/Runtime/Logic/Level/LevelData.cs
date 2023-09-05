using System;
using UnityEngine;

namespace Assets.Code.Runtime.Logic.Level
{
    [Serializable]
    public sealed class LevelData
    {
        [SerializeField]
        private SpawnPoint spawnPoint;

        [SerializeField]
        private FinishPoint finishPoint;

        public Vector2 SpawnPosition => spawnPoint.CachedTransform.position;
        public Vector2 FinishPosition => finishPoint.CachedTransform.position;
        public FinishPoint FinishPoint => finishPoint;
    }
}
