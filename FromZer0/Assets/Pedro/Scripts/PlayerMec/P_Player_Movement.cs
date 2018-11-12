using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Player_Movement : MonoBehaviour {

    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float walkXPcounter = 0;

    private GameObject SwordChild;

    private TrailRenderer tr;
    

    public Inventory inventory;

    public Collider Loot;
    

    public float dashSpeed;

    private ShakeScreen shake;




    // Use this for initialization
    void Start () {
        SwordChild = GameObject.Find("Sword");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeScreen>();
        
    }



    // Update is called once per frame
    void Update () {
        TurnToAngle();
        Move();
        //Dash();
   
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        Debug.Log("collision enter");
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
            Debug.Log("added?");
        }
    }

    public void Move()
    {

        

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;

        transform.position = new Vector2(newXpos, newYpos);

        walkXPcounter = walkXPcounter + Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if(walkXPcounter>= 100)
        {
            walkXPcounter = 0;
            var array = this.GetComponent<T_SkillTracker>().Walking;
            this.GetComponent<T_SkillTracker>().EarnXp(array, 10, false);
        }
    }

    

    public void TurnToAngle()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            //right
            //this.GetComponent<SpriteRenderer>().sprite = Right;

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 0);



        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Left
            //this.GetComponent<SpriteRenderer>().sprite = Left;

            transform.localRotation = Quaternion.Euler(0, 180, 0);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 180, 0);


        }
        else if (Input.GetKey(KeyCode.W))
        {
            //Up
            //this.GetComponent<SpriteRenderer>().sprite = Up;

            transform.localRotation = Quaternion.Euler(0, 0, 90);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 90);


        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Down
            //this.GetComponent<SpriteRenderer>().sprite = Down;
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, -90);

        }
    }

    void Dash()
    {
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            currentDashTime = 0;
        }
        if (currentDashTime < maxDashTime)
        {
            moveDirection = transform.forward * dashDistance;
            currentDashTime += dashStoppingSpeed;
        }
        else
        {
            moveDirection = Vector2.zero;
        }
        //rb.velocity = moveDirection * Time.deltaTime * dashSpeed;

        transform.position = moveDirection * Time.deltaTime * dashSpeed;*/


        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.D))
        {
            
            transform.position += new Vector3(dashSpeed * Time.deltaTime, 0, 0.0f);
            shake.CamShake();
           
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.A))
        {
            
            transform.position -= new Vector3(dashSpeed * Time.deltaTime, 0, 0.0f);
            shake.CamShake();
            
        }

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.W))
        {
            
            transform.position += new Vector3(0, dashSpeed * Time.deltaTime, 0.0f);
            shake.CamShake();
            
        }

        if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.K) || Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.S))
        {
           
            transform.position -= new Vector3(0, dashSpeed * Time.deltaTime, 0.0f);
            shake.CamShake();
            
        }

    }

}
