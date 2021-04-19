using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public void ContinueGame(){
        GameManager.LoadScene(GameManager.Instance.GetLastLevelName);
    }
}
