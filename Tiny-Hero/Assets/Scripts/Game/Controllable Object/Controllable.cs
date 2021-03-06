using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Controllable : MonoBehaviour
{
    [Header("Controllable Attributes")]

    [SerializeField] protected bool CanBePicked = true;


    [SerializeField] protected bool MakePlayerNPC;
    [SerializeField] protected bool MakePlayerColliderTrigger;

    protected bool IsBeingUsed = false;
    protected Vector2 MoveDirection = new Vector2(1f, 0f);
    protected Player Player;

    [HideInInspector] public Vector3 InitialPosition;

    public virtual void Start() {
        Player = FindObjectOfType<Player>();
        InitialPosition = transform.position;
    }

    protected void SwitchToControllableInput(){
        
            Player.InputHandler.InputActions.Player.Disable();
            Player.InputHandler.InputActions.ControlledObject.Enable();
    }

    protected void SwitchToPlayerInput(){
        
            Player.InputHandler.InputActions.Player.Enable();
            Player.InputHandler.InputActions.ControlledObject.Disable();
    }

    protected IEnumerator ReturnToInitialPosition(float seconds){
        CanBePicked = false;
        yield return transform.DOMove(InitialPosition, seconds).IsComplete();
        CanBePicked = true;
    }

    protected void AttachPlayer(bool playerIsKinematic){
        Player.transform.localScale = SetScale(new Vector3(.8f, .8f, .8f));

        Player.transform.SetParent(this.gameObject.transform);
        Player.transform.localPosition = Vector3.zero;

        if(MakePlayerNPC)
            Player.StateMachine.SetState(Player.NPCState);
        if(MakePlayerColliderTrigger)
            Player.Collider.isTrigger = true;
        
        ChangeRigidbodyProperties(playerIsKinematic);
        
    }

    protected void UnattachPlayer(bool playerIsKinematic){
        Player.transform.SetParent(null);

        Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if(MakePlayerNPC)
            Player.StateMachine.SetState(Player.JumpState);
        
        if(MakePlayerColliderTrigger)
            Player.Collider.isTrigger = false;

        ChangeRigidbodyProperties(false);

        Player.transform.localScale = SetScale(new Vector3(1f, 1f, 1f));
    }

    private void ChangeRigidbodyProperties(bool kinematic){
        Player.CharacterController.Rigidbody.isKinematic = kinematic;
        Player.CharacterController.Rigidbody.velocity = Vector2.zero;
    }

    private Vector3 SetScale(Vector3 target) => target;

}
