using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestLog : MonoBehaviour
{
    GameObject selectedButtonObject;
    public Sprite selectedSprite;


    public void GetButton()
    {
        selectedButtonObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        Debug.Log("Selected Button Object: " + selectedButtonObject.name);
    }

    public void SetButton()
    {
        if (selectedButtonObject == null)
        {
            Debug.Log("Selected Button Object is null");
            return;
        }

        Debug.Log("Selected Button Object: " + selectedButtonObject.name);
        if (selectedButtonObject.GetComponent<StoreItem>().GetItem() == null)
        {
            Debug.Log("Item is null");
        }
        if(Inventory.instance == null)
        {
            Debug.Log("Inventory is null");
        }
        Inventory.instance.AddItem(selectedButtonObject.GetComponent<StoreItem>().GetItem());
        SetChildrenImagesToNull(selectedButtonObject.transform);
        selectedButtonObject = null;
    }

    void SetChildrenImagesToNull(Transform parent)
    {
        // 부모 오브젝트의 자식들을 모두 탐색
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }

    }
}
