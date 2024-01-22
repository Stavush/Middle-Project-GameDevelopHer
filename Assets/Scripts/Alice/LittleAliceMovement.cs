using UnityEngine;

public class LittleAliceMovement : PlayerBase
{
    public bool isCrawl;
    //public bool isLittle;

    protected new void Awake()
    {
        base.Awake(); // Call the base class's Awake method
        // Additional LittleAlice-specific setup
    }

    protected new void FixedUpdate()
    {
        base.FixedUpdate(); // Call the base class's FixedUpdate method
        // Additional LittleAlice-specific FixedUpdate code
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Burrow"))
        {
            isCrawl = true;
            anim.SetBool("isCrawl", true);
            anim.SetTrigger("isLittle");
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
