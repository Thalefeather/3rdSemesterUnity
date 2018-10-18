using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Shooting : MonoBehaviour {

    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float rateOfFire = 0.5f;

    [SerializeField] float shotCounter=0;
    //[SerializeField] float minTimeBetweenShots = 0.2f;
    //[SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject laserPrefab;

    [SerializeField] bool canShoot;
    float tempAngle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shotCounter -= Time.deltaTime;
        Fire();

        //Debug.Log(angleOfMove());
        //Debug.Log(lastMovedAngle());
        //Debug.Log(Input.GetAxis("Horizontal"));
        




    }

    private void Fire()
    {
        if(Input.GetButton("Fire1"))
        {
            if(shotCounter <= 0)
            {
                shoot();
                shotCounter = rateOfFire;
            }
        }
    }

    private void shoot()
    {
        //(BUG) sometimes the direction of the projectile wont change when walking in a new direction and sometimes it wont save a new last direction
            //prolly due to when angle is called or something
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, angleOfMove())) as GameObject;

        //need to program in that last movement is saved

        laser.GetComponent<Rigidbody2D>().velocity = laser.transform.up.normalized * projectileSpeed;
    }

    private float angleOfMove()
    {

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var direction = new Vector2(x, y);

        var playerVector = new Vector2(0, Mathf.Abs(this.gameObject.transform.position.y));
        if (direction.magnitude > 0.01f)
        {
            if (x >= 0)
            {
                var projectileAngle = Vector2.Angle(direction, playerVector) * -1;
                Debug.Log("Angle of shot(-): " + projectileAngle);

                if (projectileAngle == 0 && x > 0)
                {
                    tempAngle = -90f;
                    return -90f;

                }
                else
                {
                    tempAngle = projectileAngle;
                    return projectileAngle;
                }
            }
            else
            {
                var projectileAngle = Vector2.Angle(direction, playerVector);
                Debug.Log("Angle of shot(+): " + projectileAngle);

                if (projectileAngle == 0)
                {
                    tempAngle = 90f;
                    return 90f;
                }
                else
                {
                    tempAngle = projectileAngle;
                    return projectileAngle;
                }
            }
        }
        else
        {
            return tempAngle;
        }

    }

    private void lastInputX()
    {
        float x = Input.GetAxis("Horizontal");

    }



}
