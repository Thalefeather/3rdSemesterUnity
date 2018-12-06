using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_MeleeEnemyMovement : MonoBehaviour {

    public float speed = 10;
    public float minimumDistanceToPlayer = 2;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("DISTANCE" + Vector2.Distance(this.transform.position, collision.gameObject.transform.position));
            if(Vector2.Distance(this.transform.position, collision.gameObject.transform.position) >= minimumDistanceToPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
