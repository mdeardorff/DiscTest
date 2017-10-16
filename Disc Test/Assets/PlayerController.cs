using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private GameObject[] allDiscs;
    public GameObject currentDisc;
    public GameObject aimLine;
    public GameObject camera;
    private Rigidbody rb;
    public float upForce;
    private bool charging = false;
    private float shotStrength = 0f;
    public float chargeRate;
    private float maxShot = 16f;
    private int discIndex = 0;
	// Use this for initialization
	void Start () {
        allDiscs = GameObject.FindGameObjectsWithTag("playerDisc");
        currentDisc = allDiscs[discIndex];
        rb = currentDisc.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (!charging)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                charging = true;
                StartCoroutine(Charge());
            }
            if (Input.GetMouseButtonDown(1))
            {
                currentDisc = allDiscs[++discIndex % allDiscs.Length];
                aimLine.SendMessage("ChangeTargetedDisc", currentDisc);
                camera.SendMessage("ChangeTargetedDisc", currentDisc);
                rb = currentDisc.GetComponent<Rigidbody>();
                
            }
        }

        if(Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }

    }

    IEnumerator Charge()
    {
        while (charging)
        {
            if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(aimLine.transform.up * shotStrength, ForceMode.Impulse);
                charging = false;
                shotStrength = 0;
                print("Shot with: " + shotStrength + " strength");
                yield return null;
            }
            else
            {
                shotStrength += chargeRate * Time.deltaTime;
                shotStrength = Mathf.Clamp(shotStrength, 0f, maxShot);
                yield return null;

            }
            
        }

    }

    public float getShotStrength()
    {
        return shotStrength;
    }
    public float getMaxShot()
    {
        return maxShot;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

}
