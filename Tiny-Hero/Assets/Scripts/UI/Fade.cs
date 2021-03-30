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
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public static void DoFade(float fadeDuration){

        }

        public static void ShowFade(){
            Instance._fadeImage.transform.DOScale(
                new Vector3(2f, 2f, 2f),
                .8f
            );
        }

        public static void HideFade(){
            Instance._fadeImage.transform.DOScale(
                new Vector3(0f, 0f, 0f),
                .8f
            );
        }
    }
}