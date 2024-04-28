using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StoreItem : MonoBehaviour
{
    public UIItem item;
    public Image image;




    public void SetItem(UIItem _item)
    {
        item.itemType = _item.itemType;
        item.itemName = _item.itemName;
        item.itemDescription = _item.itemDescription;
        item.itemPrice = _item.itemPrice;
        item.itemImage = _item.itemImage;
    }

    public void SetItem(string _itemName,string _itemNameText ,string _itemDescription, string _itemPrice, Sprite _itemImage)
    {
        item.itemName = _itemName;
        item.itemNameText.text = _itemNameText;
        item.itemDescription.text = _itemDescription;
        item.itemPrice.text = _itemPrice;
        item.itemImage = _itemImage;
    }

    public UIItem GetItem()
    {
        return item;
    }

    public void DestroyChildObjects()
    {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
