using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelManager : Singleton<LevelManager>, ISave
{
    [SerializeField, HideInInspector] public Vector3 _currentCheckPoint;
    [SerializeField, HideInInspector] private Player _player;
    
    [SerializeField] private string _levelName;

    #region LevelCompletion
    public delegate void onLevelComplete();
    public event onLevelComplete OnLevelComplete;
    private bool _levelCompleted;
    public bool LevelCompleted{
        get => _levelCompleted;
        private set => _levelCompleted = value;
    }

    #endregion

    public bool IsInitializingLevel = true;

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
        GameManager.Instance.SetLastLevel(_levelName);

        if(_player == null)
            _player = FindObjectOfType<Player>();

        _player.PlayerHealth.OnDead.AddListener(OnPlayerDead);

        if(_currentCheckPoint == Vector3.zero)
            return;
        _player.transform.position = _currentCheckPoint;
    }
    public void SetCheckpoint(RoomChanger checkpoint){
        _currentCheckPoint = checkpoint.transform.position;

        IsInitializingLevel = false;

        Save();
    }

    public void Load()
    {
        var data = (LevelManager) SaveData.Load(this, _levelName, true);

        _currentCheckPoint = data._currentCheckPoint;
        IsInitializingLevel = data.IsInitializingLevel;
    }

    public void Save()
    {
        SaveData.Save(this, _levelName, true);
    }

    private void OnPlayerDead() => GameManager.RestartScene();

    public void SetLevelComplete(){
        LevelCompleted = true;

        IsInitializingLevel = true;

        if(OnLevelComplete != null)
            OnLevelComplete.Invoke();

        Save();
    }
}
