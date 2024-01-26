using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerLevel;
    public int playerLines = 1;

    public Text linesText;

    public void addLines()
    {
        linesText.text = playerLines.ToString();
    }

}
