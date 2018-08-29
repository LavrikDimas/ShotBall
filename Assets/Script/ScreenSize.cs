using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour 
{
    [SerializeField]
    Transform oldSceenPoint1, oldSceenPoint2, oldSceenPoint3;

    [SerializeField]
    Transform gameScale;
	
	void Start () 
	{
        ChangeScreenSize();
    }

    void ChangeScreenSize()
    {
        var newScreenPoint1 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        var newScreenPoint2 = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        var newScreenPoint3 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        float oldSceenHeight = (oldSceenPoint1.position - oldSceenPoint2.position).magnitude;
        float oldSceenWeidth = (oldSceenPoint2.position - oldSceenPoint3.position).magnitude;
        float oldSumSize = oldSceenHeight + oldSceenWeidth;

        float newScreenHeight = (newScreenPoint1 - newScreenPoint2).magnitude;
        float newScreenWeidth = (newScreenPoint2 - newScreenPoint3).magnitude;
        float newSumSize = newScreenHeight + newScreenWeidth;

        newSumSize /= oldSumSize;

        gameScale.localScale = new Vector3(newSumSize, newSumSize, newSumSize);

    }
}
