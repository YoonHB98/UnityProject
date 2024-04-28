using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestLog : MonoBehaviour
{
    GameObject selectedButtonObject;
    Button button;
    public Sprite selectedSprite;


    public void GetButton()
    {
        selectedButtonObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        button = selectedButtonObject.GetComponent<Button>();
        button.image.sprite = selectedSprite;
        Debug.Log("Selected Button Object: " + selectedButtonObject.name);
    }

    public void SetButton()
    {
        if (button == null)
        {
            Debug.Log("Button is null");
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
