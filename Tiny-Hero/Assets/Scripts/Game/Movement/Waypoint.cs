using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Movement{
    [System.Serializable]
    public class Waypoint 
    {
        public Transform Position;
        public UnityEvent OnReachWaypoint;
        [Tooltip("Seconds the waypoint will wait to move the object")]
        ///<Summary>
        ///Seconds the waypoint will wait to move the object
        ///</Summary>
        [Range(0, 10f)] public float Seconds = .5f;
        [Tooltip("Changes the object speed when reach this waypoint")]
        ///<Summary>
        ///Changes the object speed when reach this waypoint
        ///</Summary>
        [Range(0, 100f)] public float SpeedModifier = 0f;
    }
}