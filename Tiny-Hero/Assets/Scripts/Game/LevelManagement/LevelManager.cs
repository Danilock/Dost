using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelManager : Singleton<LevelManager>, ISave
{
    [SerializeField, HideInInspector] public Vector3 _currentCheckPoint;
    [SerializeField, HideInInspector] private Player _player;
    
    [SerializeField] private string _levelName;

    public bool IsFirstTimeInLevel = true;

    public override void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else{
            Instance = this;
        }

    }

    private void OnEnable() {
        Load();
    }

    private void Start() {
        if(_player == null)
            _player = FindObjectOfType<Player>();

        _player.PlayerHealth.OnDead.AddListener(OnPlayerDead);

        if(_currentCheckPoint == Vector3.zero)
            return;
        _player.transform.position = _currentCheckPoint;
    }
    public void SetCheckpoint(RoomChanger checkpoint){
        _currentCheckPoint = checkpoint.transform.position;

        IsFirstTimeInLevel = false;

        Save();
    }

    public void Load()
    {
        var data = (LevelManager) SaveData.Load(this, _levelName);

        _currentCheckPoint = data._currentCheckPoint;
        IsFirstTimeInLevel = data.IsFirstTimeInLevel;
    }

    public void Save()
    {
        SaveData.Save(this, _levelName);
    }

    private void OnPlayerDead() => GameManager.RestartScene();
}
