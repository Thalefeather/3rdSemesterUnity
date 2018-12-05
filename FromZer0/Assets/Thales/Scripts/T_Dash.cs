using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Dash : MonoBehaviour {

    
    public float dashSpeed;
    private float dashingCounter = 0;
    public float dashDuration = 0.1f;

    [Space]
    public float dashCD;
    public float dashCDCounter = 0;
    private Rigidbody2D rb;
    public int rawDashAmount = 2;
    int currentDashAmount = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Dash();

        dashCDCounter = dashCDCounter - Time.deltaTime;
    }

    private void Dash()
    {
        if(dashingCounter <=0)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashingCounter = dashingCounter - Time.deltaTime;
        }
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
