using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Control Control;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {

        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Control.enabled = false;
        Debug.Log("Game over!");
        ReloadLevel();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Control.enabled = false;
        Debug.Log("Won!");
        ReloadLevel();
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
