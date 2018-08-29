using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManeger : MonoBehaviour 
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    List<GameObject> pool;

    [SerializeField]
    int sizePool;

    GameObject poolPrefab;


    void Start () 
	{
        AddPool();
        InvokeRepeating("UsePoolObject", 0, 0.5f);

	}
		
	void Update () 
	{
		
	}

    void AddPool()
    {
        for (int i = 0; i < sizePool; i++)
        {
            poolPrefab = Instantiate(prefab) as GameObject;
            poolPrefab.SetActive(false);
            pool.Add(poolPrefab);
        }
    }

    void UsePoolObject()
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
