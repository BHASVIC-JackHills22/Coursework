using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int playerScore;
    private int playerLevel;
    private int playerLines;

    private bool isTimed = false;

    public Text scoreText;
    public Text levelText;
    public Text linesText;
    public Text timeText;

    public GameObject StartScreen;
    public GameObject TimerText;
    public GameObject GameOverScreen;

    private float timeValue = 120;

    void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        Timer();
    }

    public void addLines()
    {
        playerLines++;
        linesText.text = playerLines.ToString();
    }

    public void addLevel()
    {
        playerLevel++;
        levelText.text = playerLevel.ToString();
    }

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void startMarathon()
    {
        StartScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void startBlitz()
    {
        StartScreen.SetActive(false);
        TimerText.SetActive(true);
        Time.timeScale = 1;
        isTimed = true;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Timer()
    {
        if (isTimed == true)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                gameOver();
            }

            displayTime(timeValue);
        }
    }

    private void displayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }

    public void showControls()
    {
        Application.OpenURL("data:text/txt;base64,SGVsbG8gaW5zdHJ1Y3Rpb25zLiAg");
    }

}
