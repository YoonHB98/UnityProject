using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static GameObject instance;
    public bool buttonactive = true;

    private void Awake()
    {
        instance = this.gameObject;
    }

    public void ButtonStatusChanged()
    {
        buttonactive = !buttonactive;
        instance.SetActive(buttonactive);
    }
}
