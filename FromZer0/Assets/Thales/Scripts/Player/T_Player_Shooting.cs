using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Player_Shooting : MonoBehaviour {

    [SerializeField] float projectileSpeed = 50f;
    [SerializeField] float rateOfFire = 0.5f;

    [SerializeField] float shotCounter=0;

    [SerializeField] GameObject laserPrefab;

    [SerializeField] bool canShoot;
    float tempAngle;
	
	// Update is called once per frame
	void Update ()
    {
        shotCounter -= Time.deltaTime;
        //fire();

        //Debug.Log(angleOfMove());
        //Debug.Log(lastMovedAngle());
        //Debug.Log(Input.GetAxis("Horizontal"));
    }

    public void fire()
    {
        if (shotCounter <= 0)
        {
            shoot();
            shotCounter = rateOfFire;
        }
    }

    private void shoot()
    {
        //THIS IS THE OLD WAY TO DO IT, IT WORKS
        //GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, angleOfMove())) as GameObject;

        //ATTEMPT AT NEW WAY (WORKS)
        GameObject laser = Instantiate(laserPrefab, transform.position, this.transform.rotation); //Quaternion.Euler Z rotation is anticlockwise
    }

    public float angleOfMove()
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



}
