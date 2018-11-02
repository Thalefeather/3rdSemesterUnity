using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //for fliping the sprite

    private SpriteRenderer mySpriteRenderer;
    private GameObject SwordChild;
    private GameObject AtackPosChild;

    


    //Sprites

    public Sprite Up, Down, Left, Right;

    //config parameters
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    Vector2 direction;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;

    float yMin;
    float yMax;

    [SerializeField] float skillWalking = 0;

    // Use this for initialization
    void Start()
    {
        SetUpMoveBoundaries();
        SwordChild = GameObject.Find("Sword");
        AtackPosChild = GameObject.Find("atackpos");
       
    }

    // This function is called just one time by Unity the moment the game loads
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();

    }

    private void Fire()//need to figure out way to make shot have same firerate even if i spam the button or hold
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }



    IEnumerator FireContinously()
    {
        while (true)
        {

            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, angleOfMove())) as GameObject;

            //formula for rotating a vector (prolly something wrong)
            //x2=cosβx1−sinβy1
            //y2=sinβx1+cosβy1
            //x2=Mathf.Cos(angleOfMove())*0-Mathf.Sin(angleOfMove()*projectileSpeed)
            //y2=Mathf.Sin(angleOfMove())*0-Mathf.Cos(angleOfMove()*projectileSpeed)
            //https://matthew-brett.github.io/teaching/rotation_2d.html

            //(FIXED)below method works in movement, not when Input values are small. 
            //(issue) varies top speed based on value of input
            //(benefit) shoot object in direction of movement
            //(fix) normalize the vector
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * projectileSpeed;
            }
            else
                if (Input.GetAxis("Vertical") == 0)//makes sure there is velocity even if Xinput and Yinput are 0
            {
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal"), 1).normalized * projectileSpeed;
            }
            //laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);



            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;
        
        transform.position = new Vector2(newXpos, newYpos);

        skillWalking = skillWalking + Mathf.Abs(deltaX) + Mathf.Abs(deltaY);
        //Debug.Log(angleOfMove());

        //Change Sprites

        if(angleOfMove() > -135 && angleOfMove() < -45)
        {
            //right
            //this.GetComponent<SpriteRenderer>().sprite = Right;

            transform.localRotation = Quaternion.Euler(0, 0, 0);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 0);
            


        }
        else if (angleOfMove() <135 && angleOfMove() >45)
        {
            //Left
            //this.GetComponent<SpriteRenderer>().sprite = Left;

            transform.localRotation = Quaternion.Euler(0, 180, 0);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 180, 0);
           

        }
        else if (angleOfMove() <45 && angleOfMove() >-45)
        {
            //Up
            //this.GetComponent<SpriteRenderer>().sprite = Up;

            transform.localRotation = Quaternion.Euler(0, 0, 90);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, 90);


        }
        else if (angleOfMove() <-135 && angleOfMove() < 135)
        {
            //Down
            //this.GetComponent<SpriteRenderer>().sprite = Down;
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            SwordChild.transform.localRotation = Quaternion.Euler(0, 0, -90);

        }


      



    }

    private void SetUpMoveBoundaries()
    {
        //viewportToWorldPoint is something to do with getting the camera size and getting a relative space out of that

        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;//padding is padding space before the border
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    private float angleOfMove()
    {
        //(FIXED)bug when switching from going up to down or vice versa, goes 0->180->0 while going same direction
        //caused by reference for vector being the center, when crossing from positive to negative, changes reference
        //fix = make Y value of position absolute

        //MIGHT CAUSE BUGS DUE TO FRAMERATE DIFFERENCES SINCE THERE IS NO * DELTA TIME BELOW

        //(Fixed) doesnt work right away, only returns values if movement that is no 90 or -90 gets made, then works as it should
        //happens because player is deadset on y axis = 0
        //fixed by returning a set amount should the angle be 0 but the input.x be greater than 0
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var direction = new Vector2(x, y);
        //Vector2 direction = GetComponent<Rigidbody2D>().velocity.normalized;
        //GetComponent<Rigidbody2D>(this.gameObject).velocity.normalized;


        var playerVector = new Vector2(0, Mathf.Abs(this.gameObject.transform.position.y));

        if (x >= 0)
        {
            var projectileAngle = Vector2.Angle(direction, playerVector) * -1;
            //Debug.Log("Angle of shot(-): " + projectileAngle);

            if (projectileAngle == 0 && x > 0)
                return -90f;
            else
                return projectileAngle;
        }
        else
        {
            var projectileAngle = Vector2.Angle(direction, playerVector);
            //Debug.Log("Angle of shot(+): " + projectileAngle);

            if (projectileAngle == 0)
                return 90f;
            else
                return projectileAngle;
        }

    }

  
    

   




}
