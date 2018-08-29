using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MakeV_ShapedLineBox : AbsMake
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

    GameObject instBox;

    Vector3 instPosition;

    float scaleBox;

    public override void Make(Transform paretn, int sumBox)
    {
        objects.Clear();
        scaleBox = (Camera.main.ViewportToWorldPoint(new Vector3(0, 0)) - Camera.main.ViewportToWorldPoint(new Vector3(1, 0))).magnitude;
        instPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        instPosition = new Vector3(instPosition.x, instPosition.y, 0);
        scaleBox /= sumBox;        
        instPosition.x += scaleBox / 2; ;
        instPosition.y += 2f;

        Vector3 instPositionOffsetY = instPosition;
        instPositionOffsetY.y -= scaleBox;
        instPositionOffsetY.x += scaleBox;

        for (int i = 0; i < sumBox - 2; i++)
        {
            float offsetPos = 2.51f;
            instBox = Instantiate(box, instPosition, Quaternion.identity) as GameObject;
            instBox.transform.localScale = new Vector3(scaleBox, scaleBox, scaleBox);
            instBox.transform.SetParent(paretn);
            instPosition.x += scaleBox * 2;

            objects.Add(instBox);
                      
        }
        for (int a = 0; a < sumBox - 3; a++)
        {
            instBox = Instantiate(box, instPositionOffsetY, Quaternion.identity) as GameObject;
            instBox.transform.localScale = new Vector3(scaleBox, scaleBox, scaleBox);
            instBox.transform.SetParent(paretn);
            instPositionOffsetY.x += scaleBox * 2;

            objects.Add(instBox);
        }

    }

    void Test1()
    {
        instPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        instPosition = new Vector3(instPosition.x, instPosition.y, 0);
        instPosition.x += 0.6f;
        instPosition.y -= 0.6f;

        Vector3 instPositionOffsetY = instPosition;
        instPositionOffsetY.y -= 1.255f;
        instPositionOffsetY.x += 1.255f;

        for (int i = 0; i < 3; i++)
        {
            float offsetPos = 2.51f;
            Instantiate(box, instPosition, Quaternion.identity);
            instPosition.x += offsetPos;

        }
        for (int a = 0; a < 2; a++)
        {
            Instantiate(box, instPositionOffsetY, Quaternion.identity);
            instPositionOffsetY.x += 2.51f;
        }
    }
}
