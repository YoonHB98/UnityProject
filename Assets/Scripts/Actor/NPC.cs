using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public CapsuleCollider capsuleCollider;
    public NPCManager npcManager;
    public bool Enter = false;
    public NPCState npcState;

    // Start is called before the first frame update
    private void Awake()
    {
        npcManager = FindObjectOfType<NPCManager>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            npcManager.OnInput(NPCState.None);
            Enter = false;
        }
    }
    //capsuleCollider와 다른 콜라이더가 충돌했을 때
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enter = true;
        }
    }

    //capsuleCollider와 다른 콜라이더가 충돌을 끝냈을 때
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            npcManager.OnInput(NPCState.None);
            Enter = false;
        }

    }

    //enter가 바뀌면 event를 발생시킨다.
    private void Update()
    {
        if (Enter)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                npcManager.OnInput(npcState);
            }
        }
    }


}
