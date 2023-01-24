using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Melee : MonoBehaviour
{
    PlayerMove playerMove;

    AudioSource audioSource;

    [Header("Melee Parameters")]
   
    [SerializeField] Vector2 meleeAttackRange = new Vector2(4f, 2f);



    [SerializeField] GameObject leftMelee;
    [SerializeField] GameObject rightMelee;

    public float timeToAttack;
    float timer;
    public int meleeDamage;


    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();

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





    void ApplyDamage(Collider2D[] colliders)
    {
        audioSource.Play();
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

    public void Attack()
    {
        //Debug.Log("Melee Attack");


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
}
