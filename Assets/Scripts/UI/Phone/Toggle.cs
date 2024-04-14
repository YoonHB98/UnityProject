using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeImage = false;

    private void Awake()
    {
        inventoryPanel = this.gameObject;
        foreach (Transform child in inventoryPanel.transform)
        {
            child.gameObject.SetActive(activeImage);
        }
    }
    
    private void Update()
    {

    }

    public void ToggleImage()
    {
        activeImage = !activeImage;
        foreach (Transform child in inventoryPanel.transform)
        {
            child.gameObject.SetActive(activeImage);
        }
    }
}
