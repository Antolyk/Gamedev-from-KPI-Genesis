using System;
using UnityEngine;

namespace Core.Movement.Data
{
    [Serializable]
    class DirectionalMovementData
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public bool FaceRight { get; set; }
    }
}
