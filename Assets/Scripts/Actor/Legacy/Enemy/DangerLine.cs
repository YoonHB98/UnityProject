using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerLine : MonoBehaviour
{
    TrailRenderer tr;
    public bool isMelee;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer> ( );
        
        tr.startColor = new Color ( 1, 0, 0, 0.7f );
        tr.endColor = new Color ( 1, 0, 0, 0.7f );
        Destroy ( gameObject,0.5f );

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMelee && other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
}
