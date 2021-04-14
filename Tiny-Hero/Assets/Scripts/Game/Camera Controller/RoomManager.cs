using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : Singleton<RoomManager>, ISave
{
    [SerializeField] private List<RoomChanger> _roomsInScene;
    [SerializeField] private Room _currentRoom;

    private void Start() {
        SetRoom(_currentRoom);
    }

    public void SetRoom(Room _newRoom){
        _currentRoom?.Camera.gameObject.SetActive(false);

        _currentRoom = _newRoom;

        _currentRoom.Camera.gameObject.SetActive(true);

        StartCoroutine(ChangeTime());
    }

    public IEnumerator ChangeTime(){
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1.2f);
        Time.timeScale = 1f;
    }

    public override void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else{
            Instance = this;
        }

        InitializeRooms();
        Load();
    }

    private void InitializeRooms(){
        RoomChanger[] allRoomsChangerInScene = FindObjectsOfType<RoomChanger>();

        foreach(RoomChanger actualRoom in allRoomsChangerInScene){
            _roomsInScene.Add(actualRoom);
        }
    }

    public void Save()
    {
        SaveData.Save(this, gameObject.name);
    }

    public void Load()
    {
        string keyName = gameObject.name;

        if(!PlayerPrefs.HasKey(keyName)){
            SetRoom(_currentRoom);
        }
        
        var data = (RoomManager) SaveData.Load(this, keyName);

        _roomsInScene = data._roomsInScene;
        _currentRoom = data._currentRoom;
    }
}
