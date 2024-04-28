using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public ItemType itemType;
    public string itemName;
    public string itemDescription;
    public string itemPrice;
    public Sprite itemImage;




    public bool Use()
    {
        return false;
    }


}
