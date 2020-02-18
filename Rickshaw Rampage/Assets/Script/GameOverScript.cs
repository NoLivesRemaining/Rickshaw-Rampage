using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameTimeScript Score;
    public Text WinText;

    
    void Update()
    {
        if (Score.Player1Score > Score.Player2Score)
        {
            WinText.text = "Player 1 Collected the Most Passengers! Enjoy your pot noodles and wine!";
        }

        if (Score.Player1Score < Score.Player2Score)
        {
            WinText.text = "Player 2 Collected the Most Passengers! Now go clean up your bike!";
        }
    }
}
