using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int playerScore;
    private int playerLevel;
    private int playerLines;

    public Text scoreText;
    public Text levelText;
    public Text linesText;

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

}
