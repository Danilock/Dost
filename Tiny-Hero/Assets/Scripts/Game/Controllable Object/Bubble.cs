using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bubble : Controllable
{
    [Header("Bubble Attributes")]
    [SerializeField] private float _force;
    [SerializeField] private ForceMode2D _forceMode;
    [Header("Activation")]
    [SerializeField] private float _timeForActivation = 1f;

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
        Bubble _otherBubble = other.gameObject.GetComponent<Bubble>();

        if(other.gameObject.CompareTag("Player")){
            ActivateBubble();
        }
        else if(other.gameObject.CompareTag("Bubble") && _otherBubble.CanBePicked){
            DesactivateBubble();

            _otherBubble.ActivateBubble();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        DesactivateBubble();
    }

    public void ActivateBubble(){
        if(!CanBePicked)
            return;

        if(Player == null)
            return;
            
        AttachPlayer(true);

        SwitchToControllableInput();

        CanBePicked = false;
            
        StartCoroutine(MoveBubble());
    }

    //Desactivate the bubble, making the object pickeable again.
    private void DesactivateBubble(){
        IsBeingUsed = false;
        _collider.isTrigger = true;

        _rgb.velocity = Vector2.zero;

        //Removing the player as child of the bubble
        UnattachPlayer(false);

        //Switching to player's main input
        SwitchToPlayerInput();

        //Returning the bubble to it's initial position
        StartCoroutine(ReturnToInitialPosition(.3f));
    }

    private IEnumerator MoveBubble(){
        _collider.isTrigger = false;
        yield return new WaitForSeconds(_timeForActivation);
        IsBeingUsed = true;
    }
}
