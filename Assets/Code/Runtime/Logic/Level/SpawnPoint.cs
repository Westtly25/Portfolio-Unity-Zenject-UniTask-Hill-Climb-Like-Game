using UnityEngine;

namespace Assets.Code.Runtime.Logic.Level
{
    public class SpawnPoint : MonoBehaviour
    {
        public Transform CachedTransform { get; private set; }

        private void Awake() =>
            CachedTransform = transform;
    }
}