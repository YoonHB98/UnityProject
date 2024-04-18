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
    public bool _tmp;

    public void Awake()
    {
        instance = this.gameObject;
    }


    public void OnInput(NPCState npcStatus)
    {
        switch (npcStatus)
        {
            case NPCState.Upgrade:
                _tmp = !First.activeSelf;
                First.SetActive(_tmp);
                break;
            case NPCState.Store:
                _tmp = !Second.activeSelf;
                Second.SetActive(_tmp);
                break;
            case NPCState.Portal:
                GameManager.instance.ChangeLevelFade("TestLevel");
                break;
            case NPCState.None:
                First.SetActive(false);
                Second.SetActive(false);
                break;
        }

    }
}
