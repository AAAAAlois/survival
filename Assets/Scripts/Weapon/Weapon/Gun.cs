using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;

    AudioSource audioSource;

    PlayerMove playerMove;

    public float timeToAttack = 1f;
    float timer;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();    //why plyaerMove = GameObject.instance.playerMove not OK?

        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            Attack();
            timer = timeToAttack;
        }
    }




    public void Attack()
    {
        audioSource.Play();

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(playerMove.lastHorizontalVector, 0f);
        //Debug.Log("spawn bullet"+ playerMove.lastHorizontalVector);
    }
}
