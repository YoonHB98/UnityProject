using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ItemPanel;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Slot _temp = GetComponent<Slot>();
        ItemDescriptionScript _tempPanel = ItemPanel.GetComponent<ItemDescriptionScript>();
        if (_temp.item == null)
        {
            Debug.Log("Item is null");
            return;
        }else
        if (_temp.item.itemName == "")
        {
            Debug.Log("Item Name is null");
            return;
        }
        _tempPanel.item.itemName = GetComponent<Slot>().item.itemName;
        _tempPanel.item.itemDescription = GetComponent<Slot>().item.itemDescription;
        ItemPanel.transform.position = new Vector3(ItemPanel.transform.position.x, 400.0f);
        _tempPanel.Change();
        //ItemPanel.transform.position = new Vector3(transform.position.x + 300, ItemPanel.transform.position.y, ItemPanel.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemPanel.transform.position = new Vector3(ItemPanel.transform.position.x, -300.0f);
    }

    private void OnDisable()
    {
        ItemPanel.transform.position = new Vector3(ItemPanel.transform.position.x, -300.0f);
    }
}