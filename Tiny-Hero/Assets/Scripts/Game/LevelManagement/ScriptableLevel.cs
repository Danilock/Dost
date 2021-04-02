using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Level", menuName = "Profiles/Level")]
public class ScriptableLevel : ScriptableObject
{
    public string LevelName;
    public Sprite LevelImage;
    [TextArea] public string LevelDescription;
}
