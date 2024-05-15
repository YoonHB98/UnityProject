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
        tr.widthMultiplier = 5.0f;
        //트레일 렌더러를 네모로
        tr.alignment = LineAlignment.View;



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
