using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionScript : MonoBehaviour
{
    public UIItem item;

    public void Change()
    {
        transform.Find("Name").GetComponent<TMP_Text>().text = item.itemName;
        transform.Find("Description").GetComponent<TMP_Text>().text = item.itemDescription;
    }
}
