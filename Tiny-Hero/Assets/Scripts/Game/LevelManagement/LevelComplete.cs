using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(LevelLoader))]
public class LevelComplete : MonoBehaviour
{
    private LevelLoader _loader;

    private void Awake() {
        _loader = GetComponent<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            
        }
    }
}
