using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum Type { A, B, C, D};
    public Type enemyType;
    public int maxHp;
    public int curHp;
    public float speed;
    public RuntimeAnimatorController[] animCon;
    public Transform Target;
    public BoxCollider meleeArea;
    public GameObject bullet;
    public bool isAttack;
    public float detectionRange;
    public LayerMask layerMask;
    public bool isDead;

    public GameObject DangerMarker;

    bool chaseStart;
    bool destroy;
    public bool isChase;
    public Rigidbody rigid;
    public BoxCollider boxCollider;
    public MeshRenderer[] meshes;
    public NavMeshAgent nav;
    public Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        meshes = GetComponentsInChildren<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        Target = GameManager.instance.player.transform;
    }

    private void OnEnable()
    {
        nav.enabled = true;
        curHp = maxHp;
        isDead = false;
        chaseStart = true;
        boxCollider.enabled = true;
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.material.color = Color.white;
        }
        gameObject.layer = 0;
    }

    public void Init(SpawnData spawnData)
    {
        speed = spawnData.speed;
        nav.speed = speed;
        maxHp = spawnData.health;
        curHp = spawnData.health;
    }

    private void Update()
    {
        if (isDead)
        {
            StopAllCoroutines();
            return;
        }
        if (Target != null && Vector3.Distance(transform.position, Target.position) <= detectionRange && destroy == false)
        {
            chaseStart = true;
        }
        if (chaseStart)
        {
             if (nav.enabled)
             {
                 nav.SetDestination(Target.position);
                 nav.isStopped = !isChase;
             }
            

        }
 
    }

    void Targerting()
    {
        if (isDead == true)
        {
            return;
        }

        float targetRadius = 0;
        float targetRange = 0;

        switch (enemyType)
        {
            case Type.A:
                targetRadius = 1.5f;
                targetRange = 3.0f;
                break;
            case Type.B:
                targetRadius = 1.0f;
                targetRange = 12.0f;
                break;
            case Type.C:
                targetRadius = 0.5f;
                targetRange = 25.0f;
                break;
        }

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

        if (rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        } 
    }

    void DangerMarkerShoot()
    {
        GameObject DangerMarkerClone = Instantiate(DangerMarker, transform.position, transform.rotation);
        Rigidbody rigidMarker = DangerMarkerClone.GetComponent<Rigidbody>();
        DangerMarkerClone.transform.position += Vector3.up *3;
        if (enemyType == Type.B)
        {
            rigidMarker.AddForce(transform.forward * 120, ForceMode.Impulse);
        }
        else
        {
            rigidMarker.velocity = transform.forward * 60;
        }
        
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        
        switch (enemyType)
        {
            case Type.A:
                //yield return new WaitForSeconds(0.2f);
                //meleeArea.enabled = true;
                //yield return new WaitForSeconds(1.0f);
                //meleeArea.enabled = false;
                //yield return new WaitForSeconds(1.0f);
                break;
            case Type.B:
                yield return new WaitForSeconds(0.5f);
                DangerMarkerShoot();
                yield return new WaitForSeconds(0.5f);
                rigid.AddForce(transform.forward * 120, ForceMode.Impulse);
                meleeArea.enabled = true;
                yield return new WaitForSeconds(2.0f);
                rigid.velocity = Vector3.zero;
                meleeArea.enabled = false;

                yield return new WaitForSeconds(3.0f);
                break;
            case Type.C:
                yield return new WaitForSeconds(0.5f);
                DangerMarkerShoot();
                yield return new WaitForSeconds(0.5f);
                GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
                rigidBullet.velocity = transform.forward * 20;
                yield return new WaitForSeconds(2.0f);
                break;
        }

        isChase = true;
        isAttack = false;


    }

    private void FixedUpdate()
    {
        Targerting();
        if (!isAttack)
        {
            FreezeVelocity();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Melee")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHp -= weapon.damage;
            Vector3 reactVec = transform.position - other.transform.position;

            StartCoroutine(OnDamage(reactVec));
        }else if(other.tag == "Bullet")
        {
            BulletSurvival Bullet = other.GetComponent<BulletSurvival>();
            curHp -= (int)Bullet.damage;
            Vector3 reactVec = transform.position - other.transform.position;

            if (other.GetComponent<Rigidbody>() != null)
            {
                Destroy(other.gameObject);
            }
            StartCoroutine(OnDamage(reactVec));
        }
    }

    private void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        foreach(MeshRenderer mesh in meshes)
        {
            mesh.material.color = Color.red;
        }
        yield return new WaitForSeconds(0.1f);
        if (curHp > 0)
        {
            foreach (MeshRenderer mesh in meshes)
            {
                mesh.material.color = Color.white;
            }
        }else{
            foreach (MeshRenderer mesh in meshes)
            {
                mesh.material.color = Color.gray;
            }
            gameObject.layer = 12;
            nav.enabled = false;
            reactVec = reactVec.normalized;
            reactVec += Vector3.up;

            rigid.AddForce(reactVec * 5, ForceMode.Impulse);
            chaseStart = false;
            yield return new WaitForSeconds(3.0f);
            gameObject.SetActive(false);

            StopAllCoroutines();
        }
    }
}
