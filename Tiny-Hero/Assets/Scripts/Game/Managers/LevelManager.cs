using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelManager : Singleton<LevelManager>, ISave
{
    [SerializeField] public Vector3 _currentCheckPoint;
    [SerializeField] private Player _player;
    
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

        Save();
    }

    public void Load()
    {
        var data = (LevelManager) SaveData.Load(this, gameObject.name);

        Debug.Log(
            JsonUtility.ToJson(data, true)
        );

        _currentCheckPoint = data._currentCheckPoint;
    }

    public void Save()
    {
        SaveData.Save(this, gameObject.name);
    }

    private void OnPlayerDead() => GameManager.RestartScene();
}
