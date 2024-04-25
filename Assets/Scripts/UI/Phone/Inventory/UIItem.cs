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
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    public bool Use()
    {
        return false;
    }


}
