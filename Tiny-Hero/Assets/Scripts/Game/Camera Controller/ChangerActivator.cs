using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class ChangerActivator : MonoBehaviour
{
    [SerializeField] private GameObject _brother;

    [SerializeField] private CinemachineVirtualCamera _from;
    [SerializeField] private CinemachineVirtualCamera _to;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            _brother.SetActive(true);

            _from.gameObject.SetActive(false);
            _to.gameObject.SetActive(true);

            Time.timeScale = 0f;

            gameObject.SetActive(false);
        }
    }

    //Every time the collider is activated it will restore the time scale to 1f
    private void OnEnable() {
        StartCoroutine(ChangeTime());
    }

    public IEnumerator ChangeTime(){
        yield return new WaitForSecondsRealtime(1.2f);
        Time.timeScale = 1f;
    }
}
