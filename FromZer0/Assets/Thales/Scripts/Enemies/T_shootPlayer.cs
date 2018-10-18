using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_shootPlayer : MonoBehaviour {

    [SerializeField] float projectileSpeed = 20f;

    //vars for enemy shot
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject laserPrefab;

    [SerializeField] bool inRange;


    private void Start()
    {
        shotCounter = 1;
    }
    private void Update()
    {
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inRange = true;
            CountDownAndShoot();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }


    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);



        laser.GetComponent<Rigidbody2D>().velocity = -this.gameObject.transform.up.normalized * projectileSpeed;
        laser.transform.up = laser.GetComponent<Rigidbody2D>().velocity;
        //Debug.Log(this.gameObject.transform.right.normalized);

    }

    private void AngleWithPlayer()
    {

    }

}
