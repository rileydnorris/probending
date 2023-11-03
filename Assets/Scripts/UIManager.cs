using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameUIContainer;
    [SerializeField]
    private GameObject endGameUIContainer;
    [SerializeField]
    private TextMeshProUGUI roundText;

    public void SetRoundText(int round)
    {
        var roundStringMap = new Dictionary<int, string>()
        {
            {1, "One"},
            {2, "Two"},
            {3, "Three"}
        };

        roundText.text = "Round: " + roundStringMap[round];
    }

    public void UpdateUI(GameStatus gs)
    {
        switch (gs)
        {
            case GameStatus.StartingGame:
                inGameUIContainer.SetActive(true);
                endGameUIContainer.SetActive(false);
                break;
            case GameStatus.InGame:
                inGameUIContainer.SetActive(true);
                endGameUIContainer.SetActive(false);
                break;
            case GameStatus.EndRound:
                inGameUIContainer.SetActive(true);
                endGameUIContainer.SetActive(false);
                break;
            case GameStatus.EndGame:
                inGameUIContainer.SetActive(false);
                endGameUIContainer.SetActive(true);
                break;
            default:
                inGameUIContainer.SetActive(false);
                endGameUIContainer.SetActive(false);
                break;
        }
    }
}
