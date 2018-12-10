using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_MeleeEnemyMov : MonoBehaviour {

    public float speed;
    EnemyMelee EM;
    GameObject EnemySwordChild;
    GameObject Player;
    GameObject Enemy;
    

    // Use this for initialization
    void Start () {
        EnemySwordChild = GameObject.Find("EnemySword");
        Enemy = GameObject.Find("MeleeEnemy");
        Player = GameObject.Find("Player");
        //SP = EnemySwordChild.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckPlayerPosition();
            

            if (Vector2.Distance(transform.position, Player.transform.position) > 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            }
        }
    }

  

    private void CheckPlayerPosition()
    {
        var relativePoint = transform.InverseTransformPoint(Player.transform.position);
        if (relativePoint.x <= 0)
        {
            print("left");

            Enemy.transform.localRotation = Quaternion.Euler(0, 0, 0);
            EnemySwordChild.GetComponent<P_EnemyMelee>().Attack();
        }
        else if (relativePoint.x > 0)
        {
            print("right");
            Enemy.transform.localRotation = Quaternion.Euler(0, 180, 0);
            EnemySwordChild.GetComponent<P_EnemyMelee>().Attack();

        }
        else
        {
            
        }
       

}


}
