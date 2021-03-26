using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Game.Movement{
    public class BaseMove : MonoBehaviour
    {
        [Header("Move Attributes")]
        [SerializeField] private float _speed;
        public float Speed{
            get => _speed;
            set => _speed = value;
        }
        public UnityEvent OnReachTargetDestination;

        protected Transform EndPosition;

        public void MoveObject(Transform target) => StartCoroutine(Move(target));
        private IEnumerator Move(Transform target){
            EndPosition = target;

            float _distance = Vector2.Distance(transform.position, target.position);

            float time = CalculateTime(_speed, _distance);

            yield return transform.DOMove(target.position, time).WaitForCompletion(true);

            OnReachTargetDestination.Invoke();
        }

        public float CalculateTime(float speed, float distance){
            return distance / speed;
        }

        public float CalculateDistance(Transform point1, Transform point2){
            return Vector2.Distance(point1.position, point2.position);
        }
    }
}