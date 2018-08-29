using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MakeMuveLineBoxe : AbsMake
{
    private List<GameObject> objects = new List<GameObject>();
    public override List<GameObject> Objects
    {
        get
        {
            return objects;
        }
    }

    [SerializeField]
    GameObject box;

    [SerializeField]
    float muveSpeed;

    float scaleBox;

    GameObject instBox;

    Vector3 instPosition;

    bool ifMovePoint;

    Vector3 firstPositon, secondPositon;

    public override void Make(Transform parent, int sumBox)
    {
        scaleBox = (Camera.main.ViewportToWorldPoint(new Vector3(0, 0)) - Camera.main.ViewportToWorldPoint(new Vector3(1, 0))).magnitude;
        scaleBox /= sumBox;

        instPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));
        instPosition.x += scaleBox / 2;
        instPosition.y += 1f;
        instPosition = new Vector3(instPosition.x, instPosition.y, 0);


        instBox = Instantiate(box, instPosition, Quaternion.identity) as GameObject;
        instBox.transform.localScale = new Vector3(scaleBox, scaleBox, scaleBox);
        instBox.transform.SetParent(parent);

        Debug.Log(instPosition.x);

        firstPositon = instBox.transform.position;

        objects.Add(instBox);
    }

    public void MoveObject(Transform leftUpperCorner, Transform rightUpperCorner)
    {
        var pos = instBox.transform.localPosition;
        var halfSize = instBox.transform.localScale.x * 0.5f;
        Debug.Log(rightUpperCorner.position.x - leftUpperCorner.position.y);
        instBox.transform.localPosition = new Vector3(Mathf.Clamp(pos.x, leftUpperCorner.localPosition.x + halfSize, rightUpperCorner.localPosition.x - halfSize), pos.y, pos.z);
    }
}
