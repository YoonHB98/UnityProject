using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val); // ��������Ʈ ����
    public OnSlotCountChange onSlotCountChange;  // ��������Ʈ �ν��Ͻ�ȭ


    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public List<Item> items = new List<Item>();

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    private void Start()
    {
        SlotCnt = 4;
    }

    public bool AddItem(Item item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(item);
            if (onItemChanged != null)
                onItemChanged.Invoke();
            return true;
        }
        return false;
    }
}
