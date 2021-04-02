using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialCoinCounter : Singleton<SpecialCoinCounter>
{   
    public static void SaveSpecialCoin(SpecialCoin coin){
        string sceneName = SceneManager.GetActiveScene().name;

        SaveData.Save(typeof(SpecialCoin), $"{sceneName}/{coin.name}");
    }

    public override void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(this.gameObject);
        else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
