using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    PlayerMove playerMove;

    [Header("Melee Parameters")]
    [SerializeField] float timeToAttack = 4f;
    [SerializeField] Vector2 meleeAttackRange = new Vector2(4f, 2f);
    [SerializeField] int meleeDamage = 1;
    float timer;

    [SerializeField] GameObject leftMelee;
    [SerializeField] GameObject rightMelee;


    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    void Attack()
    {
        //Debug.Log("Melee Attack");
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightMelee.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightMelee.transform.position, meleeAttackRange, 0f);
            ApplyDamage(colliders);

        }
        else
        {
            leftMelee.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftMelee.transform.position, meleeAttackRange, 0f);
            ApplyDamage(colliders);
        }
    }

    void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            //Debug.Log(colliders[i].gameObject.name);
            //Enemy0 e0 = colliders[i].GetComponent<Enemy0>();
            IDamageable e0 = colliders[i].GetComponent<IDamageable>();
            if (e0 != null)
            {
                e0.GetHit(meleeDamage);
            }

        }
    }
}
