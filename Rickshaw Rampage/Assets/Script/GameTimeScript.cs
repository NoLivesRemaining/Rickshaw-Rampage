using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimeScript : MonoBehaviour
{

    public int Player1Score;
    public int Player2Score;

    private float time = 180;

    public Text timerText;
    public Text Player1ScoreText;
    public Text Player2ScoreText;

    void Start()
    {
        StartCountdownTimer();
        DontDestroyOnLoad(this);
    }

    void StartCountdownTimer()
    {
        if(timerText != null)
        {
            time = 180;
            timerText.text = "Time Left: 3:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if(timerText != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            timerText.text = "Time Left: " + minutes + ":" + seconds;
        }
    }

    private void Update()
    {
        if(time == 0)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        string Player1 = Player1Score.ToString("0");
        string Player2 = Player2Score.ToString("0");
        Player1ScoreText.text =  Player1;
        Player2ScoreText.text =  Player2;
    }
}
