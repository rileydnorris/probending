using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
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
}
