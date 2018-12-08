using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Dash : MonoBehaviour {

    
    public float dashSpeed;
    public float dashingCounter = 0;
    public float dashDuration = 0.1f;

    [Space]
    public float dashCD;
    public float dashCDCounter = 0;
    private Rigidbody2D rb;
    public int rawDashAmount = 2;
    public int currentDashAmount = 0;

    [Space]
    public bool isDashing = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dashingCounter <= 0)
        {
            rb.velocity = Vector2.zero;
            isDashing = false;
        }
        else
        {
            dashingCounter = dashingCounter - Time.deltaTime;
        }

        dashCDCounter = dashCDCounter - Time.deltaTime;
    }

    /*public void DoDashOriginal()
    {
        if (dashCDCounter <= 0)
        {
            rb.velocity = this.gameObject.transform.up.normalized * dashSpeed;
            dashCDCounter = dashCD;
            dashingCounter = dashDuration;
        }
    }*/

    public void doDash()
    {
        if (dashCDCounter <= 0)
        {
            isDashing = true;
            currentDashAmount++;
            rb.velocity = this.gameObject.transform.up.normalized * dashSpeed;
            dashingCounter = dashDuration;

            if(currentDashAmount >= rawDashAmount)
            {
                dashCDCounter = dashCD;
                currentDashAmount = 0;
            }
        }
    }


}
