using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour 
{

    private void OnEnable()
    {
        Invoke("Destroy", 4);
    }
		
	void Update () 
	{
        transform.position += Vector3.forward * 19 * Time.deltaTime;
	}

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


}
