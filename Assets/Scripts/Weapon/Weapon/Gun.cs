using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    [SerializeField] GameObject bulletPrefab;

    float timer;
    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();    //why plyaerMove = GameObject.instance.playerMove not OK?
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnBullet();
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(playerMove.lastHorizontalVector, 0f);
        //Debug.Log("spawn bullet"+ playerMove.lastHorizontalVector);
    }
}
