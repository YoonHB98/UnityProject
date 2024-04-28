using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum ItemType
{
    Equipment,
    Weapon,
    Consumable,
    Goblin,
}
[System.Serializable]
public class UIItem
{
    public UIItem item;
    public ItemType itemType;
    public string itemName;
    public string itemDescription;
    public string itemPrice;
    public Sprite itemImage;
    public List<GameObject> childObjects;

    public void SetItem(UIItem _item)
    {
        item.itemType = _item.itemType;
        item.itemName = _item.itemName;
        item.itemDescription = _item.itemDescription;
        item.itemPrice = _item.itemPrice;
        item.itemImage = _item.itemImage;
    }

    public void SetItem(string _itemName, string _itemDescription, string _itemPrice, Sprite _itemImage)
    {
        item.itemName = _itemName;
        item.itemDescription = _itemDescription;
        item.itemPrice = _itemPrice;
        item.itemImage = _itemImage;
    }

    public UIItem GetItem()
    {
        return this;
    }


    public bool Use()
    {
        return false;
    }


}
