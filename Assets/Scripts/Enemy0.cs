using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour, IDamageable
{
    Character targetCharacter;

    [HideInInspector]public Rigidbody2D targetRb;

    [SerializeField] float enemySpeed;
    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;

    bool isLive = true;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //targetRb = FindObjectOfType<Character>().GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLive) return;

        Vector2 dirVec = targetRb.position - rb.position;
        //Vector2 nextVec = dirVec.normalized * enemySpeed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + nextVec);
        //rb.velocity = Vector2.zero;
        rb.velocity = dirVec.normalized * enemySpeed;
    }

    private void LateUpdate()
    {
        if (!isLive) return;

        sr.flipX = targetRb.position.x < rb.position.x;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetRb.gameObject)
        {
            EnemyAttack();
            //Debug.Log("Enemy 0 attack"+collision.gameObject);
        }
    }

    private void EnemyAttack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetRb.gameObject.GetComponent<Character>();
        }

        targetCharacter.GetHit(damage);
    }

    public void GetHit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            isLive = false;
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}
