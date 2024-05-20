using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCircle : MonoBehaviour
{
    public Material material;
    public Vector3 Pos;
    public float _BorderScale = 0.1f;
    public bool Active = false;

    private void Awake()
    {
        Pos = new Vector3(-1000, -1000, -1000);
        material.SetVector("_Center", new Vector4(Pos.x, Pos.y, Pos.z, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        material.SetVector("_Center", new Vector4(Pos.x, Pos.y, Pos.z, 0.0f));
        if (!Active)
        {
            return;
        }
        _BorderScale += Time.deltaTime * 5.0f;
        material.SetFloat("_Border", _BorderScale);

        
    }
}