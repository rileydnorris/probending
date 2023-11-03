using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    StartingGame,
    InGame,
    EndRound,
    EndGame
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player1;
    [SerializeField]
    private GameObject _player2;
    private int _numRounds = 3;
    private int _currentRound = 1;
    private UIManager uiManager;

    private GameStatus _gameStatus = GameStatus.StartingGame;

    void Start()
    {
        uiManager = GetComponent<UIManager>();
        StartRound();
    }

    void ResetPlayer()
    {
        _player1.transform.position = new Vector3(-2.6f, -1.3f, 0);
        _player1.GetComponent<DamageReceiver>().Reset();
        _player1.GetComponent<ObjectStatus>().Reset();
        _player1.GetComponent<ObjectStatus>().isDisabled = false;
        _player1.GetComponent<AnimationHandler>().Reset();

        _player2.transform.position = new Vector3(2.6f, -1.3f, 0);
        _player2.GetComponent<DamageReceiver>().Reset();
        _player2.GetComponent<ObjectStatus>().Reset();
        _player2.GetComponent<ObjectStatus>().isDisabled = false;
        _player2.GetComponent<AnimationHandler>().Reset();
    }

    void EndGame()
    {
        // TODO: how game over screen
        Debug.Log("Game ending");
        UpdateGameStatus(GameStatus.EndGame);
    }

    IEnumerator StartRoundAfter()
    {
        UpdateGameStatus(GameStatus.StartingGame);
        yield return new WaitForSeconds(3.0f);
        StartRound();
    }

    void UpdateGameStatus(GameStatus gs)
    {
        _gameStatus = gs;
        uiManager.SetRoundText(_currentRound);
        uiManager.UpdateUI(_gameStatus);
    }

    public void StartRound()
    {
        // TODO: Start countdown
        ResetPlayer();
        UpdateGameStatus(GameStatus.InGame);
    }

    public void EndRound()
    {
        // TODO: Show "start next round" prompt
        Debug.Log("Ending Round");
        UpdateGameStatus(GameStatus.EndRound);
        if (_currentRound >= _numRounds)
        {
            EndGame();
        }
        else
        {
            _currentRound += 1;
            StartCoroutine(StartRoundAfter());
        }
    }

    public void RestartGame()
    {
        _currentRound = 1;
        StartCoroutine(StartRoundAfter());
    }
}
