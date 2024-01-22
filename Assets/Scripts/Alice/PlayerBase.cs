using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public Rigidbody2D theRB;
    protected Animator anim;
    public float moveSpeed;
    Vector2 moveDirection = Vector2.zero;

    protected bool movingRight;
    protected bool movingUp;

    public SpriteRenderer theSR;

    protected void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movingRight = true;
    }

    protected void Update()
    {

    }

    protected void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        moveDirection = new Vector2(moveX, moveY).normalized;
        theRB.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetFloat("Vertical", Mathf.Abs(theRB.velocity.y));

        if (movingRight)
        {
            theSR.flipX = true;
            //anim.SetBool("isMovingDown", false);

            if (theRB.velocity.x > 0.1f)
            {
                movingRight = false;
                //anim.SetBool("isMovingDown", false);
            }
        }
        else
        {
            theSR.flipX = false;

            if (theRB.velocity.x < 0f)
            {
                movingRight = true;
            }
        }


        if (theRB.velocity.y < -0.1f)
        {
            movingUp = false;
            anim.SetBool("isMovingDown", true);
        }
        else
        {
            anim.SetBool("isMovingDown", false);
        }

        /*if (theRB.velocity.y > 0f)
        {
            movingUp = true;
            anim.SetBool("moveDown", false);
        }*/
    }
}
