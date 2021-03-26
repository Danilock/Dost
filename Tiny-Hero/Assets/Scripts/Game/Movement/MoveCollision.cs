using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Movement{
    [RequireComponent(typeof(BoxCollider2D))]
    public class MoveCollision : BaseMove
    {
        [SerializeField] private Waypoint _startPosition;
        [SerializeField] private Waypoint _endPosition;

        [SerializeField] private bool _drawGizmos = true;
        [SerializeField] private bool _canBeUsed = true;

        private Collider2D _collider;

        private void Start() {
            _collider = GetComponent<Collider2D>();

            _endPosition.OnReachWaypoint.AddListener(() => {
                StartCoroutine(MoveFromWaypointToOther(_endPosition, _startPosition));
            });

            _startPosition.OnReachWaypoint.AddListener(() => {
                _canBeUsed = true;
                _collider.enabled = false;
                _collider.enabled = true;
            });
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Player")){
                if(_canBeUsed){
                    _canBeUsed = false;

                    StartCoroutine(MoveFromWaypointToOther(_startPosition, _endPosition));
                }

                other.transform.SetParent(this.transform);
            }
        }

        private void OnCollisionExit2D(Collision2D other) {
            if(other.gameObject.CompareTag("Player")){
                other.transform.SetParent(null);
            }
        }

        private IEnumerator MoveFromWaypointToOther(Waypoint from, Waypoint to){
            if(from.Seconds > 0f) 
                yield return new WaitForSeconds(from.Seconds);

            float distance = CalculateDistance(from.Position, to.Position);

            float time = CalculateTime(Speed, distance);

            yield return transform.DOMove(to.Position.position, time).WaitForCompletion(true);

            to.OnReachWaypoint.Invoke();
        }

        private void OnDrawGizmos() {
            if(_startPosition.Position == null || _endPosition.Position == null || !_drawGizmos)
                return;
            
            Gizmos.color = Color.green;

            Gizmos.DrawSphere(_startPosition.Position.position, .3f);
            Gizmos.DrawSphere(_endPosition.Position.position, .3f);

            Gizmos.DrawLine(_startPosition.Position.position, _endPosition.Position.position);
        }
    }
}