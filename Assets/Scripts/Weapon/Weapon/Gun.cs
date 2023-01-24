using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : SkillBase
{

    [SerializeField] GameObject bulletPrefab;

    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();    //why plyaerMove = GameObject.instance.playerMove not OK?
    }



 

    public override void Attack()
    {

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(playerMove.lastHorizontalVector, 0f);
        //Debug.Log("spawn bullet"+ playerMove.lastHorizontalVector);
    }
}
