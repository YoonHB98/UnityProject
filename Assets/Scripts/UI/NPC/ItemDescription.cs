using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ItemPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemPanel.SetActive(true);
        ItemPanel.transform.position = new Vector3(transform.position.x + 300, ItemPanel.transform.position.y, ItemPanel.transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemPanel.SetActive(false);
    }

    private void OnDisable()
    {
        ItemPanel.SetActive(false);
    }
}