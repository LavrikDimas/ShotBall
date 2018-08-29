using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    private static int minScore;
    private static int maxScore;
    private static int score = 0;

    public static int MinScore
    {
        get
        {
            return minScore;
        }

        set
        {
            minScore = value;
        }
    }

    public static int MaxScore
    {
        get
        {
            return maxScore;
        }

        set
        {
            maxScore = value;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    private void Awake()
    {
        GrowGamePoints();
    }

    private void Start()
    {
        minScore = Random.Range(1, 3);
        maxScore = Random.Range(5, 10);
    }

    void GrowGamePoints()
    {
        if (Score >= MaxScore * 3.5f)
        {
            MinScore *= 2;
            MaxScore *= 2;
        }
    }
}
