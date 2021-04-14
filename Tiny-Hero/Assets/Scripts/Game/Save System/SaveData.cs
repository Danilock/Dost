using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData
{
    private static string SceneName{
        get{
            return SceneManager.GetActiveScene().name;
        }
    }
    public static void Save(object type, string keySave){
        var data = JsonUtility.ToJson(type, true);

        PlayerPrefs.SetString(SceneName + "/" + keySave, data);
        PlayerPrefs.Save();
    }

    public static object Load(object obj, string key){
        var instance = obj;

        JsonUtility.FromJsonOverwrite(
            PlayerPrefs.GetString(SceneName + "/" + key),
            obj
        );

        return instance;
    }
}
