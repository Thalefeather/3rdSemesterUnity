using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Dash : MonoBehaviour {

    
    public float dashSpeed;
    private float dashingCounter = 0;
    public float dashDuration = 0.1f;

    [Space]
    public float dashCD;
    private float dashCDCounter = 0;
    private Rigidbody2D rb;

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
        if(Input.GetKeyDown(KeyCode.K) && dashCDCounter <= 0)
        {
            rb.velocity = this.gameObject.transform.up.normalized * dashSpeed;
            dashCDCounter = dashCD;
            dashingCounter = dashDuration;
        }

        if(dashingCounter <=0)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashingCounter = dashingCounter - Time.deltaTime;
        }
    }
}
