using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bubble : Controllable
{
    [Header("Bubble Attributes")]
    [SerializeField] private float _force;
    [SerializeField] private ForceMode2D _forceMode;

    [Header("Desactivation")]
    [SerializeField] private bool _desactivateBySeconds = false;
    [SerializeField] private float _seconds;
    private Rigidbody2D _rgb;

    private Collider2D _collider;

    public override void Start() {
        base.Start();

        _rgb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update() {
        if(!IsBeingUsed)
            return;
        MoveDirection = Player.InputHandler.InputActions.ControlledObject.Move.ReadValue<Vector2>();
   
        if(Player.InputHandler.InputActions.ControlledObject.Exit.triggered){
            DesactivateBubble();
        }
    }

    private void FixedUpdate() {
        if(!IsBeingUsed)
            return;
        _rgb.AddForce(MoveDirection * _force * Time.fixedDeltaTime, _forceMode);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player")){
            if(Player == null || !CanBePicked)
                return;
            
            AttachPlayer(true);

            SwitchToControllableInput();

            CanBePicked = false;
            
            StartCoroutine(MoveBubble());
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        DesactivateBubble();
    }

    private void DesactivateBubble(){
        IsBeingUsed = false;
        _collider.isTrigger = true;

        //Returning the bubble to it's initial position
        StartCoroutine(ReturnToInitialPosition(2f));

        //Switching to player's main input
        SwitchToPlayerInput();

        //Removing the player as child of the bubble
        UnattachPlayer(false);

        StopCoroutine(DesactivateBubbleBySeconds());
    }

    private IEnumerator MoveBubble(){
        yield return new WaitForSeconds(1f);
        _collider.isTrigger = false;
        IsBeingUsed = true;

        if(_desactivateBySeconds)
            StartCoroutine(DesactivateBubbleBySeconds());
    }

    private IEnumerator DesactivateBubbleBySeconds(){
        yield return new WaitForSeconds(_seconds);
        DesactivateBubble();
    }
}
