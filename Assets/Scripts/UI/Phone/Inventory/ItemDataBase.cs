using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;
    private void Awake()
    {
        instance = this;
    }
    public List<UIItem> items = new List<UIItem>();

    public GameObject ItemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(ItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<DropItem>().SetItem(items[Random.Range(0, items.Count)]);
        }
    }
}
