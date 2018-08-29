using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MakeLineBox : AbsMake
{
    [SerializeField]
    GameObject box;

    GameObject instBox;

    Vector3 instPosition;

    float scaleBox;

    private List<GameObject> objects = new List<GameObject>();
    public override List<GameObject> Objects
    {
        get
        {
            return objects;
        }
    }

    public override void Make(Transform parent, int sumBox)
    {
        objects.Clear();

        scaleBox = (Camera.main.ViewportToWorldPoint(new Vector3(0, 0)) - Camera.main.ViewportToWorldPoint(new Vector3(1, 0))).magnitude;
        instPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        instPosition = new Vector3(instPosition.x, instPosition.y, 0);
        scaleBox /= sumBox;        
        instPosition.x += scaleBox / 2; ;
        instPosition.y += 1f;        

        for (int i = 0; i < sumBox; i++)
        {
            instBox = Instantiate(box, instPosition, Quaternion.identity) as GameObject;
            instBox.transform.localScale = new Vector3(scaleBox, scaleBox, scaleBox);
            instBox.transform.SetParent(parent);

            instPosition.x += scaleBox;

            objects.Add(instBox);
        }
    }
}
