using System;
using UnityEngine;
using Assets.Code.Runtime.Logic.Character;

namespace Assets.Code.Runtime.Logic.Level
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FinishPoint : MonoBehaviour
    {
        private bool isTriggered = false;

        public Transform CachedTransform { get; private set; }

        public event Action Finished;

        private void Awake() =>
            CachedTransform = transform;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Vehicle>(out Vehicle player) && !isTriggered)
            {
                isTriggered = true;
                Finished?.Invoke();
            }
        }
    }
}