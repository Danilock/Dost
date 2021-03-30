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
    #endregion
    public PlayerInput Input;
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

    private void Start() {
        StateMachine.SetState(InGameState);
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

    private IEnumerator LoadSceneAsync(string sceneName){
        Fade.ShowFade();

        yield return new WaitForSeconds(1f);
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Fade.HideFade();
    }
    #endregion
}
