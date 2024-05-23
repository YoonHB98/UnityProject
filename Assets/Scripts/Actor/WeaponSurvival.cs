using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSurvival : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;
    Player player;

    float timer;

    private void Awake()
    {


    }

    private void Start()
    {
        player = GameManager.instance.player;
        Init();

    }
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.position = GameManager.instance.player.transform.position;
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                break;

            default:
                timer += Time.deltaTime;
                
                if (timer > speed)
                {
                    timer = 0;
                    Fire();
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp(20, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;

        if (id == 0)
        {
            Batch();
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                speed = 1.3f;
                break;
        }

    }

    private void Batch()
    {
        for (int i = 0; i < count; i++)
        {

            Transform bullet;
            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
            }
            bullet.parent = transform;

            bullet.localPosition = new Vector3(0, 5, 0);
            bullet.localRotation = Quaternion.Euler(0, 180, 90);

            Vector3 rotVec = Vector3.right * 360 * i / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.forward * 3.5f, Space.World);
            bullet.GetComponent<BulletSurvival>().Init(damage, -1, Vector3.zero); // -1 is infinity per

        }
    }

    void Fire()
    {
        if (player.scanner.nearestTarget == null)
        {
            return;
        }

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - GameManager.instance.player.transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = player.transform.position + new Vector3(0, 5, 0);
        bullet.rotation = Quaternion.LookRotation(dir);
        bullet.GetComponent<BulletSurvival>().Init(damage, count, dir);
    }
}
