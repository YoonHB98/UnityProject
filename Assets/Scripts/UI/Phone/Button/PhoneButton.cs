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
        //PhoneBT.name + "NBt"가 있다면
       GameObject _tmp = GameObject.Find(PhoneBT.name + "NBt");
        if (_tmp != null && _tmp.GetComponent<Toggle>() != null)
        {
            ToggleUI = _tmp.GetComponent<Toggle>();
        }else
        {
            Debug.Log("ToggleUI is null");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOnClick()
    {
        ToggleUI.ToggleImage();
        ButtonManager.instance.GetComponent<ButtonManager>().ButtonStatusChanged();
        return;
        //switch (state)
        //{
        //    case ButtonState.Box:
        //        ToggleUI.ToggleImage();
        //        ButtonManager.instance.GetComponent<ButtonManager>().ButtonStatusChanged();
        //        Debug.Log("Box");
        //        break;
        //    case ButtonState.Encyclopedia:
        //        Debug.Log("Setting");
        //        break;
        //    case ButtonState.Profile:
        //        Debug.Log("None");
        //        break;
        //}
    }
}
