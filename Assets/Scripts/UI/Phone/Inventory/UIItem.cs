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
    public TMP_Text itemNameText;
    public TMP_Text itemDescription;
    public TMP_Text itemPrice;
    public Sprite itemImage;




    public bool Use()
    {
        return false;
    }


}
