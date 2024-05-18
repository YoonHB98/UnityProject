using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCircle : MonoBehaviour
{
    public Material material;
    public Vector3 mousePos;

    private RaycastHit _Hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
        {
            mousePos = _Hit.point;
        }

        material.SetVector("_Center", new Vector4(mousePos.x, mousePos.y, mousePos.z, 0.0f));
        
    }
}
