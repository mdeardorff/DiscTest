using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject currentDisc;
    public GameObject aimLine;
    public Rigidbody rb;
    public float forceStrength;
    public float upForce;
    private bool charging = false;
    private float shotStrength = 0f;
    public float chargeRate;
    public float maxShot = 10;
	// Use this for initialization
	void Start () {
        rb = currentDisc.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!charging)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                charging = true;
                StartCoroutine(Charge());
            }
        }
        
        if(Input.GetKeyDown("w"))
        {
            rb.AddForce(Vector3.forward * forceStrength + Vector3.up * upForce, ForceMode.Impulse);
        }
        if(Input.GetKeyDown("a"))
        {
            rb.AddForce(Vector3.left * forceStrength + Vector3.up * upForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("d"))
        {
            rb.AddForce(Vector3.right * forceStrength + Vector3.up * upForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("s"))
        {
            rb.AddForce(Vector3.back * forceStrength + Vector3.up * upForce, ForceMode.Impulse);
        }
        if(Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
        }

    }

    IEnumerator Charge()
    {
        while (charging)
        {
            if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(Vector3.forward * shotStrength, ForceMode.Impulse);
                charging = false;
                shotStrength = 0;
                print("Shot with: " + shotStrength + " strength");
                yield return null;
            }
            else
            {
                shotStrength += chargeRate * Time.deltaTime;
                shotStrength = Mathf.Clamp(shotStrength, 0f, 10f);
                print(shotStrength);
                yield return null;

            }
        }

    }

}
