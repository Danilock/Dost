using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class RoomChanger : MonoBehaviour
{
    [SerializeField] private GameObject _brother;
    [SerializeField] private Room _to;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            CameraSwitch();
        }
    }

    public void CameraSwitch(){
        _brother.SetActive(true);

        RoomManager.Instance.SetRoom(_to);
        LevelManager.Instance.SetCheckpoint(transform);

        gameObject.SetActive(false);
    }
}
