using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Movement : MonoBehaviour {

    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float DashMoveSpeed = 50f;
    [SerializeField] float DashDuration = 0.05f;
    [SerializeField] float walkXPcounter = 0;

    bool isDashing = false;


    // Use this for initialization
    void Start () {
        //rb = this.gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        //rb.bodyType = RigidbodyType2D.Dynamic;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move()
    {
        float deltaX;
        float deltaY;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        float newXpos;
        float newYpos;

        deltaX = inputX * Time.deltaTime * moveSpeed;
        deltaY = inputY * Time.deltaTime * moveSpeed;

        newXpos = transform.position.x + deltaX;
        newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);


        
        //this will lead to xp always be earned when holding directional inputs, nezed to adapt so its only when walking
        walkXPcounter = walkXPcounter + Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if(walkXPcounter>= 100)
        {
            walkXPcounter = 0;
            var array = this.GetComponent<T_SkillTracker>().Walking;
            this.GetComponent<T_SkillTracker>().EarnXp(array, 10);
        }
    }

    private void StartDash()
    {
        isDashing = true;
        this.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
        //rb.velocity = new Vector2(0, 50);

        Invoke("EndDash", DashDuration);
    }

    private void EndDash()
    {
        isDashing = false;
        this.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
        //rb.velocity = new Vector2(0, 0);
    }

}
