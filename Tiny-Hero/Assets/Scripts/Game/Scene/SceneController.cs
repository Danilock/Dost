using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    private void Start() {
        //Sets a gameManager game state when scene loads

        GameManager.Instance.SetManagerState(_gameState);
    }
}
