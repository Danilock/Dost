using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _inputActions;
    public PlayerInput InputActions { get => _inputActions; }

    public Vector2 Move { get; private set; }

    private void Awake() {
        _inputActions = new PlayerInput();
        _inputActions.Enable();
    }

    private void Update() {
        Move = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    [ContextMenu("Desactivate Movement")]
    public void DesactivateMovement() => _inputActions.Player.Move.Disable();

    [ContextMenu("Desactivate Jump")]
    public void DesactivateJump() => _inputActions.Player.Jump.Disable();

    [ContextMenu("Activate Movement")]
    public void ActivateMovement() => _inputActions.Player.Move.Enable();

    [ContextMenu("Activate Jump")]
    public void ActivateJump() => _inputActions.Player.Jump.Enable();

    public bool JumpTriggered(){
        return _inputActions.Player.Jump.triggered;
    }

    public bool MoveTriggered(){
        return _inputActions.Player.Move.triggered;
    }
}
