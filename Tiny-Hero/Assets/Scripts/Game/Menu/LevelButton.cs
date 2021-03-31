using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _levelName;

    [Header("Scriptable profile")]
    [SerializeField] private ScriptableLevel _scrLevel;
    // Start is called before the first frame update
    void Start()
    {
        _image.sprite = _scrLevel.LevelImage;
        _levelName.text = _scrLevel.LevelName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
