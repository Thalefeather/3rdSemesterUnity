using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_RestorePoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("HEALING FOUNTAIN");
        if(collision.tag == "Player")
        {
           // Debug.Log("izza player");
            collision.GetComponent<T_Health>().FullRestore();
        }
    }
}
