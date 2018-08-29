using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour 
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    float poolSize;

    [SerializeField]
    List<GameObject> pool;

    GameObject poolPrefab;
	
	void Start () 
	{
        CreatePool();
        InvokeRepeating("UsePool", 0, 0.07f);
    }

    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            poolPrefab = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            poolPrefab.SetActive(false);
            pool.Add(poolPrefab);
        }       
    }

    void UsePool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].transform.position = transform.position;
                pool[i].transform.rotation = transform.rotation;
                pool[i].SetActive(true);

                break;
            }                     
        }
    }
}
