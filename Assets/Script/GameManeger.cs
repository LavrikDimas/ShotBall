using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{

    [SerializeField]
    Transform canvas;

    [SerializeField]
    ScoreManeger scoreManeger;

    [System.Serializable]
    public class Wave
    {
        public AbsMake make;
        public MovementBehaviour movement;
    }   

    [SerializeField]
    List<Wave> makeWall;

    [SerializeField]
    private Transform rightBorder, leftBorder;

    bool nextWalls;

    private int WaveIndex
    {
        get
        {
            return 0;
        }
    }

    void Start () 
	{
        //Invoke("MakeWall", 0.5f);
        InvokeRepeating("MakeWall", 0, 4f);

        //makeWall[0].Make(canvas, 5);
        //makeWall[1].Make(canvas, 5);
        //makeWall[WaveIndex].make.Make(canvas, 5);
        //makeLineBox.Make(canvas);
        //makeV_ShapedLineBox.Make(canvas);
    }

    private void Update()
    {
        foreach (var obj in makeWall[WaveIndex].make.Objects)
            if (obj != null)
                makeWall[WaveIndex].movement.MoveObject(obj, leftBorder, rightBorder);
    }       

    void CheckNextWall()
    {        
        if (scoreManeger.GameScore >= 50)
            nextWalls = true;

        if (scoreManeger.GameScore >= 100)
            nextWalls = false;

        if (scoreManeger.GameScore >= 150)
            nextWalls = true;
    }

    void MakeWall()
    {
        if (!nextWalls)
            makeWall[WaveIndex].make.Make(canvas, 5);

        if (nextWalls)
            makeWall[WaveIndex].make.Make(canvas, 5);

    }
}
