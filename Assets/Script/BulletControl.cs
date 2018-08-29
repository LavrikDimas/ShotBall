using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour 
{

    private void OnEnable()
    {
        Invoke("Destroy", 1);
    }
    
    void Update () 
	{
        transform.position += Vector3.up * 8 * Time.deltaTime;
	}

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            Destroy();
        }
    }

}
