using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePhone : MonoBehaviour
{

    private void Active()
    {
        //escŰ�� ������ y��ġ�� 365�� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.position = new Vector3(0, 365, 0);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
