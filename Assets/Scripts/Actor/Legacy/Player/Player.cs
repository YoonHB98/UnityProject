using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DefaultActor
{
    Animator anim;
    Rigidbody rigid;
    MeshRenderer[] meshs;
    Vector3 dodgeVec;
    public GameObject[] weapons;
    public bool[] hasWeapons;
    public Camera followCamera;
    public Scanner scanner;

    bool isBossAtk;
    //jump
    bool jDown;
    bool isJump;
    //dodge
    bool dDown;
    bool isDodge;
    //interaction
    bool iDown;
    //itemswap
    bool sDown1;
    bool sDown2;
    bool isswap;
    //weapon
    bool fDown;
    bool isFireReady;
    //피격
    bool isDamage;

    GameObject nearObject;
    Weapon equipWeapon;

    int equipWeaponIndex = -1;
    float fireDelay;

    private void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    private void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interaction");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        fDown = Input.GetButton("Fire1");

        if(hAxis == 0 && vAxis == 0 && !isBossAtk)
        {
            rigid.velocity = Vector3.zero;
        }
    }

    private void move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if(isDodge)
        {
            moveVec = dodgeVec;
        }

        //rigid.AddForce(moveVec * _speed, ForceMode.Acceleration);

        //if(rigid.velocity.magnitude > _speed)
        //{
        //    rigid.velocity = rigid.velocity.normalized * _speed;
        //}
        if(!isBossAtk)
        {
            rigid.velocity = moveVec * _speed;
        }

        //transform.position += moveVec * _speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }

    void Turn()
    {
        //키보드에 의한 회전
        transform.LookAt(transform.position + moveVec);
        //마우스에 의한 회전
        if (fDown)
        {
            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //ray에 물체가 닿으면 hit에 저장 100은 레이의 길이
            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 nextVec = hit.point - transform.position;
                nextVec.y = 0;
                transform.LookAt(transform.position + nextVec);
            }
        }

    }
    private void Jump()
    {
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge)
        {
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    private void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge)
        {
            dodgeVec = moveVec;
            _speed = _speed * 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.4f);
        }
    }

    private void DodgeOut()
    {
        _speed = _speed * 0.5f;
        isDodge = false;
    }

    private void Attack()
    {
        if (equipWeapon == null)
        {
            return;
        }

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if (fDown && isFireReady && !isDodge && !isswap)
        {
            equipWeapon.Use();
            anim.SetTrigger("doSwing");
            fireDelay = 0;
        }
    }
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        meshs = GetComponentsInChildren<MeshRenderer>();
        scanner = GetComponent<Scanner>();
    }

    private void SetAnimation()
    {

    }

    private void Rotation()
    {
        transform.LookAt(transform.position + moveVec);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //bool paused = GameManager.instance.GetisPaused();
        //if(paused)
        //{
        //    return;
        //}
        GetInput();
        move();
        //Rotation();
        Turn();
        FreezeRotation();
        SetAnimation();
        //Jump();
        Attack();
        Dodge();
        Interaction();
        swap();
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon" || other.tag == "Coin" || other.tag == "Shop")
        {
            nearObject = other.gameObject;
        }else
        {
            return;
        }

        Debug.Log(nearObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
        {
            nearObject = null;
        }else if(other.tag == "Coin")
        {
            nearObject = null;
        }else if(other.tag == "Shop")
        {
            Shop shop = nearObject.GetComponent<Shop>();
            shop.Exit();
            nearObject = null;
        }
        else
        {
            return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                case Item.ItemType.COIN:
                    _coin += item.value;
                    if(_coin > maxCoin)
                    {
                        _coin = maxCoin;
                    }
                    break;
            }
            Destroy(other.gameObject);
        }else if (other.tag == "EnemyBullet")
        {
            if(!isDamage)
            {
                Bullet enemyBullet = other.GetComponent<Bullet>();
                _hp -= enemyBullet.damage;

                isBossAtk = other.name == "Boss Melee Area";
                StartCoroutine(OnDamage(isBossAtk));
            }
        }
    }

    IEnumerator OnDamage(bool isBossAtk)
    {
        isDamage = true;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
        }

        if (isBossAtk)
        {
            rigid.AddForce(transform.forward * -25, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(1.0f);
        isDamage = false;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }

        if (isBossAtk)
        {
            rigid.velocity = Vector3.zero;
            isDamage = false;
        }
    }

    private void swap()
    {
        if(sDown1 && (!hasWeapons[0] || equipWeaponIndex == 0))
        {
            return;
        }
        if (sDown2 && (!hasWeapons[1] || equipWeaponIndex == 1))
        {
            return;
        }

        int weaponIndex = -1;
        if(sDown1)
        {
            weaponIndex = 0;
        }
        if(sDown2)
        {
            weaponIndex = 1;
        }
        if((sDown1 || sDown2) && !isJump)
        {
            if(equipWeapon != null) 
            {
                equipWeapon.gameObject.SetActive(false);
            }

            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);
            //idle일 경우에만 애니메이션 실행
            if(!isJump && !isDodge && moveVec.magnitude < 0.003f)
            {
                anim.SetTrigger("doSwap");
                isswap = true;

                Invoke("SwapOut", 0.4f);
            }else
            {
                isswap = true;
                Invoke("SwapOut", 0.4f);
            }


        }
    }

    private void SwapOut()
    {
        isswap = false;
    }

    private void Interaction()
    {
        if (iDown && nearObject != null && !isJump)
        {
            if (nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasWeapons[weaponIndex] = true;

                Destroy(nearObject);
            }else if(nearObject.tag == "Coin")
            {
                Item item = nearObject.GetComponent<Item>();
                _coin += item.value;
                if(_coin > maxCoin)
                {
                    _coin = maxCoin;
                }
                Destroy(nearObject);
            }else if(nearObject.tag == "Shop")
            {
                Shop shop = nearObject.GetComponent<Shop>();
                shop.Enter(this);
            }
        }
    }


}

