using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
    public new Animator animation;
    public Rigidbody2D rb;
    public float jump_force = 10;
    public float strafe_force = 10;
    private Touch touchCount;
    private Vector2 touchPosStart, touchPosEnd;

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y > 0)
        {
            animation.SetBool("Falling", true);
        }
        else
        {
            animation.SetBool("Falling", false);
        }

        if(Input.touchCount > 0)
        {
            touchCount = Input.GetTouch(0);
             if(touchCount.phase == TouchPhase.Began)
            {
                touchPosStart = touchCount.position;
            }
             else if(touchCount.phase == TouchPhase.Moved || touchCount.phase == TouchPhase.Ended)
            {
                touchPosEnd = touchCount.position;

                if((touchPosStart.x - touchPosEnd.x ) <= 0)
                {
                    transform.Translate(Vector2.right * strafe_force * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector2.left * strafe_force * Time.deltaTime);
                }
            }
        }
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * strafe_force * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * strafe_force * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "obicne_Platforme")
        {
            rb.velocity = Vector2.up * jump_force;
        }
    }
}
