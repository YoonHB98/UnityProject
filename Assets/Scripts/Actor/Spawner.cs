using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    float timer;
    Vector3 pos = new Vector3(0, 0, 0);
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();// �ڱ� �ڽ��� ���� - �ڽĵ��� 1���� ����
        this.transform.position = pos;
    }
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 1.0f)
        {
            timer = 0;
            int index = Random.Range(0, spawnPoint.Length);
            Spawn();
        }
        transform.position = GameManager.instance.player.transform.position + pos;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.pool.Get(1);
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
