using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace UI{
    public class Fade : Singleton<Fade>
    {
        [SerializeField] private Image _fadeImage;
        public override void Awake()
        {
            if(Instance != null && Instance != this)
                Destroy(this.gameObject);
            else{
                Instance = this;
            }
        }

        public static void DoFade(float fadeDuration){

        }

        public static void ShowFade(){
            Instance._fadeImage.DOColor(
                Color.black, .8f
            );
        }

        public static void HideFade(){
            Instance._fadeImage.DOColor(
                Color.black * 0f, .8f
            );
        }
    }
}