using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string _levelToLoad;

    public void LoadLevel()
    {
        GameManager.LoadScene(_levelToLoad);
    }
}
