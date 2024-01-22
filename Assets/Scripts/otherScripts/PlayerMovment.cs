using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody2D theRB;
    private Animator anim;
    public float moveSpeed;
    Vector2 moveDirection = Vector2.zero;

    private bool movingRight;
    private bool movingUp;

    public SpriteRenderer theSR;

    public bool isCrawl;

    // Start is called before the first frame update
    void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void FixedUpdate()
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

            if (theRB.velocity.x > 0f)
            {
                movingRight = false;
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

        if (movingUp)
        {
            if (isCrawl)
            {
                theSR.flipY = true;

                if (theRB.velocity.y < 0.1f)
                {
                    movingUp = false;
                }
            }
        }
        else
        {
            theSR.flipY = false;

            if (theRB.velocity.y > 0.1f)
            {
                movingUp = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Burrow"))
        {
            isCrawl = true;
            anim.SetBool("isCrawl", true);
        }
    }

  

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Burrow") && isCrawl == true)
        {
            isCrawl = false;
            anim.SetBool("isCrawl", false);
            theSR.flipY = false;
            if (!movingUp)
            {
                theSR.flipY = false;
            }
        }
    }
}
