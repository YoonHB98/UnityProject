using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static GameObject instance;
    public GameObject PhoneBT;
    public GameObject Phone;
    public bool buttonactive = true;
    public ButtonState ButtonStatus;

    private void Awake()
    {
        instance = this.gameObject;
    }

    public void ButtonStatusChanged(ButtonState state)
    {
        buttonactive = !buttonactive;
        PhoneBT.SetActive(buttonactive);
        ButtonStatus = state;
    }

    public void ButtonStatusChanged()
    {
        buttonactive = !buttonactive;
        PhoneBT.SetActive(buttonactive);
    }

    private void Update()
    {
        escape();
    }

    public void escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (ButtonStatus)
            {
                case ButtonState.Nope:
                    break;
                case ButtonState.None:
                    Phone.SetActive(true);
                    ButtonStatus = ButtonState.Idle;
                    break;
                case ButtonState.Idle:
                    Phone.SetActive(false);
                    ButtonStatus = ButtonState.None;
                    break;
                case ButtonState.Box:
                case ButtonState.Encyclopedia:
                case ButtonState.Profile:
                    GameObject _tmp = GameObject.Find(ButtonStatus.ToString() + "NBt");
                    if (_tmp != null && _tmp.GetComponent<Toggle>() != null)
                    {
                        _tmp.GetComponent<Toggle>().ToggleImage();
                    }
                    ButtonStatusChanged();
                    ButtonStatus = ButtonState.Idle;
                    break;
            }
        }
    }
}
