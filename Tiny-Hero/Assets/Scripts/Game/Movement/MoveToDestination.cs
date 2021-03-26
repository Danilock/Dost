using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement{
    public class MoveToDestination : BaseMove
    {
        [Header("Destination")]
        [SerializeField] private Transform TargetPosition;

        private void Start() {
            MoveObject(TargetPosition);
        }
    }
}