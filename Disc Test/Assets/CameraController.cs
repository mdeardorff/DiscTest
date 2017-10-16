using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform cameraPosition;
    public float rotateSpeed;
    private Vector3 latestOffset;
    public GameObject currentTarget;

	// Use this for initialization
	void Start () {
        latestOffset = transform.position - currentTarget.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (currentTarget.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {

            if (currentTarget.transform.position + latestOffset != transform.position)
            {
                transform.position = currentTarget.transform.position + latestOffset;
            }

            if (Input.GetKey("q"))
            {
                transform.RotateAround(currentTarget.transform.position, currentTarget.transform.up, -rotateSpeed * Time.deltaTime);
                latestOffset = transform.position - currentTarget.transform.position;
            }
            if (Input.GetKey("e"))
            {
                transform.RotateAround(currentTarget.transform.position, currentTarget.transform.up, rotateSpeed * Time.deltaTime);
                latestOffset = transform.position - currentTarget.transform.position;
            }
        }
    }

    public void ChangeTargetedDisc(GameObject currentDisc)
    {
        print("CHANGE OF DISC");
        currentTarget = currentDisc;
    }
}
