using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreObject : ScoreCounter
{
    Text scoreText;
    int scoreObject;

    void Start () 
	{
        scoreText = gameObject.GetComponentInChildren<Text>();
        scoreObject = Random.Range(MinScore, MaxScore);
    }
		
	void Update () 
	{
        scoreText.text = scoreObject.ToString();       
        Destroy(gameObject, 6);
        //Debug.Log("MinScore" + MinScore);
        //Debug.Log("MaxScore" + MaxScore);       
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Bullet"))
        {
            Score++;

            scoreObject--;
            if (scoreObject <= 0)
                Destroy(gameObject);            
        }
    }

}
