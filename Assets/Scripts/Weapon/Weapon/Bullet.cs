using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;
    bool hitDecteced = false;

    [SerializeField] float speed;
    public int bulletDamage = 1;

    public void SetDirection(float dir_x,float dir_y)
    {
        direction = new Vector3(dir_x, dir_y, 0f);


    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Time.frameCount % 6 == 0)
        {
            Collider2D[] bulletHit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            foreach (Collider2D a in bulletHit)
            {
                IDamageable enemy = a.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    //Debug.Log("bullet hit");
                    enemy.GetHit(bulletDamage);
                    hitDecteced = true;
                }
            }

            if (hitDecteced)
            {
                Destroy(gameObject);
            }
        }


    }
}
