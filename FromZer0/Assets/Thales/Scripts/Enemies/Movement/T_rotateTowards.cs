﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_rotateTowards : MonoBehaviour {

    // Angular speed in radians per sec.
    [SerializeField] float speed = 2f;
    [SerializeField] float sign = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log(this.gameObject.name + " colliding with: " + collision.tag);
            //transform.Rotate(0, 0, Time.deltaTime);
            Vector3 vectorToTarget = collision.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90*sign;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }
}

