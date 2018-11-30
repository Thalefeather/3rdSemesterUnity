using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerCanvas : MonoBehaviour {

    private GameObject PC; 

	// Use this for initialization
	void Start () {
        PC = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = PC.transform.position;
	}
}
