using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player1;
    [SerializeField]
    private GameObject _player2;
    private int _numRounds = 3;
    private int _currentRound = 1;
    private UIManager uiManager;

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
    }

    public void StartRound()
    {
        // TODO: Start countdown
        uiManager.SetRoundText(_currentRound);
        Debug.Log("Starting Round");
        ResetPlayer();
    }

    public void EndRound()
    {
        // TODO: Show "start next round" prompt
        Debug.Log("Ending Round");
        _currentRound += 1;
        if (_currentRound > _numRounds)
        {
            EndGame();
        }
        else
        {
            StartCoroutine(StartRoundAfter());
        }
    }

    IEnumerator StartRoundAfter()
    {
        yield return new WaitForSeconds(3.0f);
        StartRound();
    }
}
