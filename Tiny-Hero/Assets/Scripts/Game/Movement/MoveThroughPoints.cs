using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement{
    public class MoveThroughPoints : BaseMove
    {
        [Header("Move Through Points")]
        [SerializeField] private List<Waypoint> _wayPoints;
        private Waypoint _currentWaypoint;
        private int _currentWaypointIndex = 0; 

        [Header("Gizmos")]
        [SerializeField] private Color _gizmosColor = Color.green;
        [SerializeField, Range(0, 1)] private float _sphereSize = .3f;
        [SerializeField] private bool _drawGizmos = true;

        private void Start() {
            OnReachTargetDestination.AddListener(SelectNextWaypoint);

            MoveObject(_wayPoints[0].Position);
        }

        private void SelectNextWaypoint(){
            _currentWaypoint?.OnReachWaypoint.Invoke();
            
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _wayPoints.Count;
            _currentWaypoint = _wayPoints[_currentWaypointIndex];
            
            StartCoroutine(MoveObjectToPosition());
        }

        private IEnumerator MoveObjectToPosition(){
            if(_currentWaypoint.SpeedModifier != 0) Speed = _currentWaypoint.SpeedModifier;
            yield return new WaitForSeconds(_currentWaypoint.Seconds);

            MoveObject(_currentWaypoint.Position);
        }

        private void OnDrawGizmos() {
            if(_wayPoints == null || _wayPoints.Count < 2 || !_drawGizmos)
                return;
                

            Gizmos.color = _gizmosColor;

            for(int i = 0; i < _wayPoints.Count; i++){
                Gizmos.DrawSphere(_wayPoints[i].Position.position, _sphereSize);

                Gizmos.DrawLine(
                    _wayPoints[i].Position.position,
                    _wayPoints[(i + 1) % _wayPoints.Count].Position.position);
            }
        }
    }
}