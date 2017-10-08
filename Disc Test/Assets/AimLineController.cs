using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineController : MonoBehaviour {

    private Vector3 offset = new Vector3(0f, 0f, .2f);
    private Vector3 latestOffset;
    public GameObject currentTarget;
    public float rotateSpeed = 60f;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = currentTarget.transform.position + offset;
        latestOffset = transform.position - currentTarget.transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTarget.GetComponent<Rigidbody>().velocity == new Vector3(0, 0))
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
        if (currentTarget.transform.position + latestOffset != transform.position)
        {
            transform.position = currentTarget.transform.position + latestOffset;
        }

        if(Input.GetKey("q"))
        {
            transform.RotateAround(currentTarget.transform.position, transform.forward, rotateSpeed * Time.deltaTime);
            latestOffset = transform.position - currentTarget.transform.position;
            print(latestOffset.ToString());
        }
        if(Input.GetKey("e"))
        {
            transform.RotateAround(currentTarget.transform.position, transform.forward, -rotateSpeed * Time.deltaTime);
            latestOffset = transform.position - currentTarget.transform.position;
            
        }

    }
}
