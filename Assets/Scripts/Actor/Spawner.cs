using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;
    Vector3 pos = new Vector3(0, 0, 0);
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();// 자기 자신을 포함 - 자식들은 1부터 시작
        this.transform.position = pos;
    }
    void Update()
    {
        timer = timer + Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);
        if (timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }
        transform.position = GameManager.instance.player.transform.position + pos;
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(level);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int monsterType;
    public float spawnTime;
    public int health;
    public float speed;
}