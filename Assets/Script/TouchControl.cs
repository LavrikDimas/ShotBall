using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour 
{
    [SerializeField]
    Transform boxPosition;

    Vector3 minOffset;
    Vector3 maxOffset;
    Vector3 touchPosition;

    void Start () 
	{
        minOffset = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        minOffset.x += 0.5f;
        maxOffset = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        maxOffset.x -= 0.5f;
	}
		
	void Update () 
	{
        TouchControll();

        //Debug.Log(touchPosition);
	}

    void TouchControll()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPosition.z = 0;
        touchPosition.y = boxPosition.position.y;
        touchPosition.x = Mathf.Clamp(touchPosition.x, minOffset.x, maxOffset.x);

        boxPosition.position = Vector3.MoveTowards(boxPosition.position, touchPosition, 15 * Time.deltaTime);
    }

    
}
