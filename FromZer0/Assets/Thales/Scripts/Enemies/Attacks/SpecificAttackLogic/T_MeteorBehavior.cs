using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_MeteorBehavior : MonoBehaviour {

    [SerializeField] float damage = 50f;
    [SerializeField] float timeToExplode = 0.5f;

    public GameObject explosionObj;

    float timeCounter = 0;
    Color newColor;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter = timeCounter + Time.deltaTime;

        if(timeCounter >= timeToExplode)
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            sprite.color = Color.red;
            GameObject explosion = Instantiate(explosionObj, transform.position, Quaternion.identity);
            Invoke("destroyThis", 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<T_Health>().TakeDamage(damage, 0);
        }
        
    }

    private void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
