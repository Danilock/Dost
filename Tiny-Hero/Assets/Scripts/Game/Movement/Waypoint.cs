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
    }
}