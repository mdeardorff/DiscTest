using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineController : MonoBehaviour {

    public GameObject playerController;
    private Vector3 latestOffset;
    private GameObject currentTarget;
    public float rotateSpeed = 60f;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start ()
    {
        currentTarget = playerController.GetComponent<PlayerController>().currentDisc;
        spriteRenderer = GetComponent<SpriteRenderer>();
        latestOffset = transform.position - currentTarget.transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTarget.GetComponent<Rigidbody>().velocity == new Vector3(0, 0))
        {
            spriteRenderer.enabled = true;
            if (currentTarget.transform.position + latestOffset != transform.position)
            {
                transform.position = currentTarget.transform.position + latestOffset;
            }

            if (Input.GetKey("q"))
            {
                transform.RotateAround(currentTarget.transform.position, transform.forward, rotateSpeed * Time.deltaTime);
                latestOffset = transform.position - currentTarget.transform.position;
                print(latestOffset.ToString());
            }
            if (Input.GetKey("e"))
            {
                transform.RotateAround(currentTarget.transform.position, transform.forward, -rotateSpeed * Time.deltaTime);
                latestOffset = transform.position - currentTarget.transform.position;

            }
        }
        else
        {
            spriteRenderer.enabled = false;
        }
       

    }

    public void ChangeTargetedDisc(GameObject currentDisc)
    {
        currentTarget = currentDisc;
    }
}
