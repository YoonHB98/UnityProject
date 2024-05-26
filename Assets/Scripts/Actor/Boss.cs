using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Enemy
{
    Vector3 lookVec;
    Vector3 tauntVec;
    public bool isLook;
    public float ThinkTime;
    public float jumpForce = 10.0f; // 점프 힘
    public float fallSpeed = 10.0f; // 낙하 속도
    public ShowCircle Area;
    public ShowSwing SwingArea;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        meshes = GetComponentsInChildren<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();

        nav.isStopped = true;
        StartCoroutine(Think());
    }

    private void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        if (isDead)
        {
            StopAllCoroutines();
            return;
        }
        if (isLook)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 2.0f;
            transform.LookAt(Target.position + lookVec);
        }else
        {
            nav.SetDestination(tauntVec);
        }
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(ThinkTime);

        int ranAction = Random.Range(0, 4);
        //int ranAction = 3;
        switch (ranAction)
        {
            case 0:
            case 1:
                StartCoroutine(MeleeAttack());
                break;
            case 2:
                StartCoroutine(JumpAttack());
                break;
            case 3:
                StartCoroutine(Swing());
                break;
        }
    }

    IEnumerator MeleeAttack()
    {
        //anim.SetTrigger("MeleeAttack"); 애니메이션 들어오면 설정해주세요
        yield return new WaitForSeconds(2.0f); // 애니메이션 맞게 시간 설정해주세요
        StartCoroutine(Think());
    }

    IEnumerator JumpAttack()
    {
        Area.Active = true;
        Area._BorderScale = 0.1f;
        tauntVec = Target.position + lookVec;
        Area.Pos = tauntVec;
        isLook = false;
        nav.isStopped = false;
        boxCollider.enabled = false;
        //anim.SetTrigger("JumpAttack");
        yield return new WaitForSeconds(2.0f);
        Area.Active = false;
        yield return new WaitForSeconds(2.0f);
        meleeArea.enabled = true;
        Area.Pos = new Vector3(-1000, -1000, -1000);

        Area._BorderScale = 0.1f;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(1.0f);
        isLook = true;
        nav.isStopped = true;
        boxCollider.enabled = true;


        StartCoroutine(Think());

    }

    IEnumerator Swing()
    {
        //anim.SetTrigger("Swing"); 
        isLook = false;
        SwingArea.Pos = transform.position;
        SwingArea.Active = true;
        yield return new WaitForSeconds(2.0f);
        isLook = true;
        SwingArea.Active = false;
        SwingArea.Pos = new Vector3(-1000, -1000, -1000);
        StartCoroutine(Think());
    }


}
