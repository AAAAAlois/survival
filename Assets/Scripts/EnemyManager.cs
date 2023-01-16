using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy0;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    void SpawnEnemy()
    {
        Vector3 enemyPosition = GenerateRandomPosition();
        enemyPosition += player.transform.position;
        GameObject newEnemy = Instantiate(enemy0, enemyPosition, Quaternion.identity);
        newEnemy.transform.SetParent(this.transform);
        newEnemy.GetComponent<Enemy0>().targetRb = player.GetComponent<Rigidbody2D>();
    }

    Vector3 GenerateRandomPosition()
    {
        Vector3 enemyPosition = new Vector3();
        float f = Random.value > 0.5f ? -1f : 1f;

        if (Random.value > 0.5f)
        {
            enemyPosition.x = Random.Range(-spawnArea.x, spawnArea.x);
            enemyPosition.y = spawnArea.y * f;
        }
        else
        {
            enemyPosition.y = Random.Range(-spawnArea.y, spawnArea.y);
            enemyPosition.x = spawnArea.x * f;
        }

        enemyPosition.z = 0;

        return enemyPosition;
    }
}
