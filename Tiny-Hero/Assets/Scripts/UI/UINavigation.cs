using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI{
    [RequireComponent(typeof(CanvasGroup))]
    public class UINavigation : MonoBehaviour, IPointerEnterHandler
    {
        private Selectable _selectable;

        private void Start() {
            _selectable = GetComponent<Selectable>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.Instance.SetCursorSelectionPosition(_selectable);
        }
    }
}