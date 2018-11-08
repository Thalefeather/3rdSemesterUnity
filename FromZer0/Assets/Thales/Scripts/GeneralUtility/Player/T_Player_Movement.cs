using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Movement : MonoBehaviour {

    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float walkXPcounter = 0;
    private GameObject SwordChild;



    // Use this for initialization
    void Start () {
        SwordChild = GameObject.Find("Sword");
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
        //MoveAngle();
        TurnToAngle();


        //this will lead to xp always be earned when holding directional inputs, nezed to adapt so its only when walking
        walkXPcounter = walkXPcounter + Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if(walkXPcounter>= 100)
        {
            walkXPcounter = 0;
            var array = this.GetComponent<T_SkillTracker>().Walking;
            this.GetComponent<T_SkillTracker>().EarnXp(array, 10);
        }
    }


    public void P_TurnToAngle()
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

    private void MoveAngle()
    {
        //need to fix this for when x>0 && y!=0
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var playerVector = new Vector2(0, Mathf.Abs(this.gameObject.transform.position.x));
        var direction = new Vector2(x, y);

        float directionAngle;

        if (x<0)
        {
            directionAngle = Vector2.Angle(direction, playerVector) + 90;
            transform.localRotation = Quaternion.Euler(0, 0, directionAngle);
        }
        else
        { 
            directionAngle = Vector2.Angle(direction, playerVector) - 90;
            transform.localRotation = Quaternion.Euler(0, 0, directionAngle);
        }
        

        

    }

    public void TurnToAngle()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            //down left
            transform.localRotation = Quaternion.Euler(0, 0, 225);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 225);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            //down right
            transform.localRotation = Quaternion.Euler(0, 0, -45);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, -45);

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            //up left
            transform.localRotation = Quaternion.Euler(0, 0, 135);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 135);

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            //up right
            transform.localRotation = Quaternion.Euler(0, 0, 45);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 45);

        }
        else if (Input.GetKey(KeyCode.D))
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


}
