using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum ItemType
{
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
}
