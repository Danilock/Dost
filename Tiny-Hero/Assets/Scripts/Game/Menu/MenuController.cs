using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _continueButton;
    [SerializeField] private TMP_Text _continueText;
    void Start()
    {
        GameManager.Instance.StateMachine.SetState(GameManager.Instance.InMenuState);   
    
        InitializeContinueButton();
    }

    private void InitializeContinueButton(){
        _continueButton.interactable = GameManager.Instance.IsGameSaved ? true : false;
    
        _continueText.color = _continueText.color * (
            _continueButton.interactable ? 1f : .4f
        );
    }
}
