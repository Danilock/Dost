using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpecialCoin : MonoBehaviour
{
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            StartCoroutine(MoveCoin());

            SpecialCoinCounter.SaveSpecialCoin(this);
        }
    }

    private IEnumerator MoveCoin(){
        transform.DOMove(transform.up * 30f, 2f);
        yield return new WaitForSeconds(1f);
    }
}
