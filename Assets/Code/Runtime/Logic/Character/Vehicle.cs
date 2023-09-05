using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Runtime.Logic.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Vehicle : MonoBehaviour, IPlayerController
    {
        [Header("Components")]
        [SerializeField]
        private Rigidbody2D[] wheelsRb2Ds;

        [Header("Car Data")]
        [SerializeField]
        private VehicleData vehicleData;
       
        [SerializeField, Range(-10f, 10f)]
        private float currentSpeed;

        [SerializeField]
        private bool isMoving = false;
        [SerializeField]
        private bool isBreaking = false;

        private void FixedUpdate()
        {
            currentSpeed = CalculatedSpeed();

            if (isMoving)
            {
                for (int i = 0; i < wheelsRb2Ds.Length; i++)
                    wheelsRb2Ds[i].AddTorque(-currentSpeed);
            }
            
            if (isBreaking)
            {
                currentSpeed = 200 * Time.fixedDeltaTime;
                for (int i = 0; i < wheelsRb2Ds.Length; i++)
                    wheelsRb2Ds[i].AddTorque(currentSpeed);
            }
        }

        private float CalculatedSpeed() =>
             vehicleData.Speed * Time.fixedDeltaTime;

        public void ShouldMove(bool isMoving) =>
            this.isMoving = isMoving;

        public void ShouldBreak(bool isBreaking) =>
            this.isBreaking = isBreaking;
    }
}