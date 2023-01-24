using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    SkillManager skillManager;

    Rigidbody2D rb;
    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;

    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField] float speed;

    

    // Start is called before the first frame update
    void Start()
    {
        skillManager = GetComponent<SkillManager>();

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        movementVector = new Vector2();

        lastHorizontalVector = 1f;
        lastVerticalVector = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
            //spriteRenderer.flipX = movementVector.x < 0;
        }

        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        rb.velocity = movementVector * (speed + skillManager.addSpeedAmount);

        if(movementVector.x != 0)
        {
            spriteRenderer.flipX = movementVector.x < 0;
        }

        if(movementVector != new Vector2(0,0))
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
}
