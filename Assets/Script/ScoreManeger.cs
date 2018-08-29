using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : ScoreCounter
{
    [SerializeField]
    Text scoreText;

    private static int gameScore;

    public int GameScore { get { return gameScore; } }

    void Update () 
	{
        Debug.Log(GameScore);
        gameScore = Score;
        scoreText.text = gameScore.ToString();     
    }

}
