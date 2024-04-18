using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject StoreItemPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        StoreItemPanel.SetActive(true);
        StoreItemPanel.transform.position = new Vector3(transform.position.x +300, StoreItemPanel.transform.position.y, StoreItemPanel.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StoreItemPanel.SetActive(false);
    }

    private void OnDisable()
    {
        StoreItemPanel.SetActive(false);
    }
}