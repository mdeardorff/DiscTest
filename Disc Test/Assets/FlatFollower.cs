using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFollower : MonoBehaviour {
    public GameObject currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = currentTarget.transform.position;		
	}
}
