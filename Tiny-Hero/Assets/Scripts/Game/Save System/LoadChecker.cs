using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<Summary>
///An object will find for own concurrences in the database if find one
// then it will be desactivated
///</Summary>
public class LoadChecker : MonoBehaviour
{
    private void Start() {
        string sceneName = SceneManager.GetActiveScene().name;

        if(PlayerPrefs.HasKey($"{sceneName}/{gameObject.name}")){
            gameObject.SetActive(false);
        }
    }
}
