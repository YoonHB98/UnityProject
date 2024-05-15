using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    public Slot[] slots;
    public Transform slotHolder;

    private void Awake()
    {
        inventory = Inventory.instance;
    }
    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<Slot>();
        foreach (Slot slot in slots)
        {
            slot.gameObject.GetComponent<ItemDescription>().ItemPanel = GameObject.Find("ItemDescription");
        }

        inventory.onSlotCountChange += SlotChange;
        inventory.SlotCnt++;
        inventory.onItemChanged += RedrawSlotUI;
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void AddSlot()
    {
        inventory.SlotCnt++;
    }

    public void RedrawSlotUI() 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for (int i = 0; i < inventory.items.Count; i++)
        {
            slots[i].item = inventory.items[i];
            slots[i].UpdateSlot();
        }
    }

    //slot의 버튼을 누르면 그 슬롯을 제외한 나머지 슬롯의 이미지를 원래대로 돌려놓음
    public void RevertSlotImage()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isChanged == false)
            {
                slots[i].RevertImage();
            }else
            {
                slots[i].isChanged = false;
            }

        }
    }




}
