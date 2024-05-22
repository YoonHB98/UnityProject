using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolmanager : MonoBehaviour
{
    public static Poolmanager instance;
    public GameObject[] prefabs;
    public int[] counts;
    public List<GameObject>[] pools;

    private void Awake()
    {
        instance = this;
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i <pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                item.SetActive(true);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}

