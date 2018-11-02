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


        
        //this will lead to xp always be earned when holding directional inputs, nezed to adapt so its only when walking
        walkXPcounter = walkXPcounter + Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));

        if(walkXPcounter>= 100)
        {
            walkXPcounter = 0;
            var array = this.GetComponent<T_SkillTracker>().Walking;
            this.GetComponent<T_SkillTracker>().EarnXp(array, 10);
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
}
