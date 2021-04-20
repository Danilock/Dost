using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace UI{
    public class UIManager : Singleton<UIManager>
    {
        private GameObject _selectionCursor;
        public override void Awake()
        {
            if(Instance != null && Instance != this)
                Destroy(this.gameObject);
            else{
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public void SetCursorSelectionPosition(Selectable target){
            _selectionCursor = GameObject.FindGameObjectWithTag("SelectionCursor");

            if(!target.interactable)
                return;

            _selectionCursor.transform.DOMove(
                target.transform.position, .3f
            );
        }
    }
}