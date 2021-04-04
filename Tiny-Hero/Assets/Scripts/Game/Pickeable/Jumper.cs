using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private Vector2 _force;
    [SerializeField] private ForceMode2D _forcemode;

    [Header("Parent")]
    [SerializeField] private GameObject _parent;

    private Collider2D _collider;

    private void Start() {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Rigidbody2D rgb = other.gameObject.GetComponent<Rigidbody2D>();

            rgb.velocity = Vector2.zero;
            rgb.AddForce(_force, _forcemode);
            
            StartCoroutine(HandlePlayerInput(other, rgb));
        }
    }

    private IEnumerator HandlePlayerInput(Collision2D player, Rigidbody2D rgb){
        Player playerInstance = player.gameObject.GetComponent<Player>();

        playerInstance.CharacterController.CanMove = false;

        _collider.isTrigger = true;

        yield return new WaitForSeconds(1.2f);

        _collider.isTrigger = false;

        playerInstance.CharacterController.CanMove = true;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;

        Vector2 endPosition = (Vector2)transform.position + _force;

        Gizmos.DrawLine(transform.position, endPosition);
    }
}
