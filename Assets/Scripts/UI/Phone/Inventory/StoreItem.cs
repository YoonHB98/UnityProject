using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StoreItem : MonoBehaviour
{
    public UIItem item;
    public Image image;


    public Transform FindInChildren(Transform parent, string name)
    {
        Transform result = null;

        // 부모 오브젝트의 모든 자식들을 검사
        foreach (Transform child in parent)
        {
            // 자식의 이름이 원하는 이름과 일치하는지 확인
            if (child.name == name)
            {
                // 일치하는 경우 해당 Transform 반환
                result = child;
                break;
            }
            // 일치하지 않는 경우 재귀적으로 자식의 자식을 검색
            result = FindInChildren(child, name);
            if (result != null)
                break;
        }

        return result;
    }

    private void Start()
    {
        item.itemImage = FindInChildren(transform, "itemImage").GetComponent<Image>().sprite;
        item.itemName = FindInChildren(transform, "itemName").GetComponent<TMP_Text>().text;
        item.itemDescription = FindInChildren(transform, "Description").GetComponent<TMP_Text>().text;
        item.itemPrice = FindInChildren(transform, "Price").GetComponent<TMP_Text>().text;
    }


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
        item.itemDescription = _itemDescription;
        item.itemPrice = _itemPrice;
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
