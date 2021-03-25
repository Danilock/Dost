using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Movement{
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

            float time = _distance / _speed;

            yield return transform.DOMove(target.position, time).WaitForCompletion(true);

            OnReachTargetDestination.Invoke();
        }
    }
}