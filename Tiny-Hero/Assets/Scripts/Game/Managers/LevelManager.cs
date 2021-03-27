using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>, ISave
{
    [SerializeField] private Transform _currentCheckPoint;
    [SerializeField] private Player _player;

    public void SetCheckpoint(Transform checkpoint){
        _currentCheckPoint = checkpoint;

        Save();
    }
    
    public override void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else{
            Instance = this;
        }

        Load();

        if(_player == null)
            _player = FindObjectOfType<Player>();
    }

    private void Start() {
        if(_currentCheckPoint == null)
            return;
        _player.transform.position = _currentCheckPoint.transform.position;
    }

    public void Load()
    {
        var data = (LevelManager) SaveData.Load(this, gameObject.GetInstanceID().ToString());

        _currentCheckPoint = data._currentCheckPoint;
    }

    public void Save()
    {
        SaveData.Save(this, gameObject.GetInstanceID().ToString());
    }
}
