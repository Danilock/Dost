using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace UI{
    [RequireComponent(typeof(CanvasGroup))]
    public class UINavigation : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private GameObject _selectionCursor;

        private CanvasGroup _group;

        private void Start() {
            _group = GetComponent<CanvasGroup>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!_group.interactable)
                return;

            _selectionCursor.transform.DOMove(transform.position, .3f);
        }
    }
}