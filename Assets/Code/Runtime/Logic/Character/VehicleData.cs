using System;
using UnityEngine;

namespace Assets.Code.Runtime.Logic.Character
{
    [Serializable]
    public class VehicleData
    {
        [SerializeField, Range(0, 200)]
        private float speed;

        public float Speed => speed;
    }
}