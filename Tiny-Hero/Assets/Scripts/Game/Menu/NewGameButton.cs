using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private string _firstLevelName;
    [SerializeField] private UnityEvent _onFindGameSave;

    public void PressContinueButton(){
        if(GameManager.Instance.IsGameSaved){
            _onFindGameSave.Invoke();
            return;
        }

        InitiateNewGame();
    }

    public void InitiateNewGame(){
        PlayerPrefs.DeleteAll();

        GameManager.LoadScene(_firstLevelName);
    }
}
