using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BatAttack : MonoBehaviour {
    [SerializeField] float timeBetweenAttacks = 2f;
    [SerializeField] float currentTimeBetweenAttacks = 0f;
    [SerializeField] float attackRange = 1f;

    [Space]
    [SerializeField] GameObject slash;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CountDownAndAttack(collision);
        }
    }

    private void CountDownAndAttack(Collider2D collision)
    {
        currentTimeBetweenAttacks -= Time.deltaTime;

        if (currentTimeBetweenAttacks <= 0.5f && Vector2.Distance(this.transform.position, collision.gameObject.transform.position) <= this.gameObject.GetComponent<T_EnemyMovement>().minimumDistanceToPlayer)
        {
            attackColor();
            Invoke("attack", 0.5f);
            Invoke("mainColor", 0.5f);
            currentTimeBetweenAttacks = timeBetweenAttacks;
        }
    }

    private void attack()
    {
        GameObject attack = Instantiate(slash, this.transform.position + this.transform.up.normalized/attackRange, this.transform.rotation);
        currentTimeBetweenAttacks = timeBetweenAttacks;
    }

    private void print2()
    {
        Debug.Log("ATTACK ATTACK ATTACK");
        currentTimeBetweenAttacks = timeBetweenAttacks;
    }

    private void mainColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    private void attackColor()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
