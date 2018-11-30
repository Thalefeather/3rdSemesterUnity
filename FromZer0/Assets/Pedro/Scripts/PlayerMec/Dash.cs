using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public float timeSpentDashing = 1;
    private int direction;

    public bool isDashing = false;
    


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity);
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.A))
            {
                direction = 1;
                Debug.Log("D1");
            }
            else if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.D))
            {
                direction = 2;
                Debug.Log("D2");
            }
            else if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.W))
            {
                direction = 3;
                Debug.Log("D3");
            }
            else if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.S))
            {
                direction = 4;
                Debug.Log("D4");
            }
        } else{
                if(dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    //Debug.Log(dashTime);

                    if(direction == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                        /*iFrames();
                        Invoke("noIframes", startDashTime); */
                }
                else if(direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                        /*iFrames();
                        Invoke("noIframes", startDashTime); */
                }
                else if (direction == 3)
                    {
                        rb.velocity = Vector2.up * dashSpeed;
                        /* iFrames();
                        Invoke("noIframes", startDashTime); */
                }
                    else if (direction == 4)
                    {
                        rb.velocity = Vector2.down * dashSpeed;
                        /*iFrames();
                        Invoke("noIframes", startDashTime);*/
                }
                }
            }
	}

    void dash()
    {
        float counter = 0;
        

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.K) && counter <= 0 || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.A) && counter <= 0)
        {
            rb.velocity = Vector2.left * dashSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.K) && counter <= 0 || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.D) && counter <= 0)
        {
            rb.velocity = Vector2.right * dashSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.K) && counter <= 0 || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.W) && counter <= 0)
        {
            rb.velocity = Vector2.up * dashSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.K) && counter <= 0 || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.S) && counter <= 0)
        {
            rb.velocity = Vector2.down * dashSpeed;
        }
    }

    void iFrames()
    {
        isDashing = true;
    }
    void noIframes()
    {
        isDashing = false;
    }

}
