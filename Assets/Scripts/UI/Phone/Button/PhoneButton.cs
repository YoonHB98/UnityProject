using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    public static GameObject PhoneBT;
    public ButtonState MyState;
    public InventoryUI InventoryUI;


    public void Awake()
    {
        PhoneBT = this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOnClick()
    {
        ButtonState state = MyState;
        switch (state)
        {
            case ButtonState.Box:
                InventoryUI.ToggleInventory();
                ButtonManager.instance.GetComponent<ButtonManager>().ButtonStatusChanged();
                Debug.Log("Box");
                break;
            case ButtonState.Setting:
                Debug.Log("Setting");
                break;
            case ButtonState.None:
                Debug.Log("None");
                break;
        }
    }
}
