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

        // �θ� ������Ʈ�� ��� �ڽĵ��� �˻�
        foreach (Transform child in parent)
        {
            // �ڽ��� �̸��� ���ϴ� �̸��� ��ġ�ϴ��� Ȯ��
            if (child.name == name)
            {
                // ��ġ�ϴ� ��� �ش� Transform ��ȯ
                result = child;
                break;
            }
            // ��ġ���� �ʴ� ��� ��������� �ڽ��� �ڽ��� �˻�
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
