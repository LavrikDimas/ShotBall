using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Create linear movement")]
public class LinearMovement : MovementBehaviour
{

    public override void MoveObject(GameObject obj, Transform left, Transform right)
    {
        var pos = obj.transform.localPosition;
        var halfSize = obj.transform.localScale.x * 0.5f;
        pos += Physics.gravity * 12 * Time.deltaTime;
        var leftX = left.localPosition.x + halfSize;
        var rightX = right.localPosition.x - halfSize;
        //obj.transform.localPosition = new Vector3(Random.Range(leftX, rightX), pos.y, pos.z);
        obj.transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
    }
}
