using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePhone : MonoBehaviour
{

    private void Active()
    {
        //esc키를 누르면 y위치를 365로 설정
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
