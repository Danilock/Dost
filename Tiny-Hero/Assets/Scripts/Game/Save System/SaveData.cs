using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData
{
    public static void Save(object type, string keySave){
        var data = JsonUtility.ToJson(type, true);

        PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "/" + keySave, data);
        PlayerPrefs.Save();
    }

    public static object Load(object obj, string key){
        var instance = obj;

        JsonUtility.FromJsonOverwrite(
            PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "/" + key),
            obj
        );

        return instance;
    }
}
