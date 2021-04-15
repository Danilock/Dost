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

    public static void Save(object type, string keySave, bool ignoreSceneName){
        var data = JsonUtility.ToJson(type, true);

        if(ignoreSceneName)
            PlayerPrefs.SetString(keySave, data);
        else
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

    public static object Load(object obj, string key, bool ignoreSceneName){
        var instance = obj;

        JsonUtility.FromJsonOverwrite(
            PlayerPrefs.GetString(
                ignoreSceneName ? 
                key :
                SceneName + "/" + key 
            ),
            obj
        );

        return instance;
    }
}
