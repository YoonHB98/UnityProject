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
    //capsuleCollider�� �ٸ� �ݶ��̴��� �浹���� ��
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enter = true;
        }
    }

    //capsuleCollider�� �ٸ� �ݶ��̴��� �浹�� ������ ��
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            npcManager.OnInput(NPCState.None);
            Enter = false;
        }

    }

    //enter�� �ٲ�� event�� �߻���Ų��.
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
