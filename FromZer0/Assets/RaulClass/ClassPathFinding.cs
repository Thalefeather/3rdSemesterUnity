using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPathFinding : MonoBehaviour {
    public ClassGrid grid;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void Init()
    {
        grid = GetComponent<ClassGrid>();
        grid.Init();
    }
}
