using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSurvival : MonoBehaviour
{
    public float damage;
    public int per;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if(per > -1)
        {
            rigid.velocity = dir * 15f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy" || per == -1)
        {
            return;
        }else
        {
            per = per - 1;
        }

        if (per == -1)
        {
            rigid.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
