using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void TriggerWalkAnimation() => _playerAnimator.Play("Walk");

    public void TriggerIdleAnimation() => _playerAnimator.Play("Idle");

    public void TriggerJumpAnimation() => _playerAnimator.Play("Jump");
}
