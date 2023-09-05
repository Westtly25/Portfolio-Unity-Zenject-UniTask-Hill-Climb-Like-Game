using Assets.Code.Runtime.Logic.Character;
using UnityEngine;
using Zenject;

namespace Assets.Code.Runtime.Logic
{
    public sealed class TargetFollower : MonoBehaviour
    {
        [SerializeField, Range(1f, 4f)]
        public float smoothness;
        [SerializeField]
        public Transform targetObject;
        [SerializeField]
        private Vector3 initalOffset;
        [SerializeField]
        private Vector3 parentPosition;

        private DiContainer diContainer;

        [Inject]
        public void Construct(DiContainer diContainer) =>
            this.diContainer = diContainer;

        public void SetTarget(Transform target)
        {
            targetObject = target;

            transform.position = target.position + initalOffset;
        }

        private void FixedUpdate()
        {
            if (targetObject == null)
                ResolveTarget();

            parentPosition = targetObject.position + initalOffset;
            transform.position = Vector3.Lerp(transform.position, new Vector3(parentPosition.x, 0, parentPosition.z), smoothness * Time.fixedDeltaTime);
        }

        private void ResolveTarget() =>
            targetObject = diContainer.Resolve<Vehicle>().transform;
    }
}