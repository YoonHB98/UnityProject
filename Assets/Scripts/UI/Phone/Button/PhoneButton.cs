using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    public GameObject PhoneBT;
    public ButtonState MyName;
    public Toggle ToggleUI;


    public void Awake()
    {
        PhoneBT = this.gameObject;

    }

    // Start is called before the first frame update
    void Start()
    {
        //InventoryUI를 컴포넌트로 가지고 있는 경우에만
        if (GameObject.Find(PhoneBT.name).GetComponent<Toggle>() != null)
        {
            ToggleUI = GameObject.Find(PhoneBT.name).GetComponent<Toggle>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOnClick()
    {
        ButtonState state = MyName;
        switch (state)
        {
            case ButtonState.Box:
                ToggleUI.ToggleImage();
                ButtonManager.instance.GetComponent<ButtonManager>().ButtonStatusChanged();
                Debug.Log("Box");
                break;
            case ButtonState.Encyclopedia:
                Debug.Log("Setting");
                break;
            case ButtonState.Profile:
                Debug.Log("None");
                break;
        }
    }
}
