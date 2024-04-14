using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static GameObject instance;
    public GameObject First;
    public GameObject Second;
    public bool buttonactive = true;
    public NPCState NPCStatus;

    private void Awake()
    {
        instance = this.gameObject;
    }


    private void Update()
    {
        escape();
    }

    public void escape()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool _tmp = !First.activeSelf;
            First.SetActive(_tmp);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            bool _tmp = !Second.activeSelf;
            Second.SetActive(_tmp);
        }
    }
}
