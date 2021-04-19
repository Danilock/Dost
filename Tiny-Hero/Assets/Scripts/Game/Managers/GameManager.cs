using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;
using UnityEngine.SceneManagement;
using UI;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    #region State Machine
    public StateMachine<GameManager> StateMachine;
    public InGameState InGameState = new InGameState();
    public InPauseState InPauseState = new InPauseState();
    public InLoadingState InLoadingState = new InLoadingState();
    public InMenuState InMenuState = new InMenuState();
    #endregion
    public PlayerInput Input;

    public enum InitialState{
        InGame,
        InMenu,
        InPause
    }

    [SerializeField] private InitialState _initialState;
    public override void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }
        else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        Input = new PlayerInput();
        StateMachine = new StateMachine<GameManager>(this);
    }

    private void Update() {
        StateMachine.CurrentState.TickState(this);
    }

    public void EnablePlayerActions(){
        Input.Player.Dash.Enable();
        Input.Player.Move.Enable();
        Input.Player.Jump.Enable();
    }

    public void DisablePlayerActions(){
        Input.Player.Move.Disable();
        Input.Player.Jump.Disable();
        Input.Player.Dash.Disable();
    }

    #region Level Restart
    public static void RestartScene(){
        GameManager.Instance.StateMachine.SetState(
            GameManager.Instance.InLoadingState
        );

        GameManager.Instance.StartCoroutine(
            Instance.LoadSceneAsync(
                SceneManager.GetActiveScene().name
            )
        );
    }

    public static void LoadScene(string sceneName)
    {
        GameManager.Instance.StateMachine.SetState(
            GameManager.Instance.InLoadingState
        );

        GameManager.Instance.StartCoroutine(
            Instance.LoadSceneAsync(sceneName)
        );
    }

    private IEnumerator LoadSceneAsync(string sceneName){
        Fade.ShowFade();

        yield return new WaitForSeconds(1f);
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(.5f);

        Fade.HideFade();
    }
    #endregion

    #region 
    public void SetLastLevel(string levelName){
        PlayerPrefs.SetString("LastLevel", levelName);
        PlayerPrefs.Save();
    }

    public bool IsGameSaved{
        get => PlayerPrefs.HasKey("LastLevel");
    }

    public string GetLastLevelName{
        get => PlayerPrefs.GetString("LastLevel");
    }
    #endregion

    public void SetManagerState(InitialState state){
        switch(state){
            case InitialState.InGame:
                StateMachine.SetState(InGameState);
                break;
            case InitialState.InMenu:
                StateMachine.SetState(InMenuState);
                break;
        }
    }
}
