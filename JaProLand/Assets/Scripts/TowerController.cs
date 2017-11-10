using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private int health;

	// Use this for initialization
	void Start () {
        health = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hit ()
    {
        health = Mathf.Max(health - 1, 0);
    }

    public int getHealth ()
    {
        return health;
    }
}
