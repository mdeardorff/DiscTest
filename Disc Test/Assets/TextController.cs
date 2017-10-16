using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {

    public float shotValue;
    private TextMeshProUGUI textMesh;
    public GameObject playerController;
    private bool charging = false;
	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMeshProUGUI>();

        textMesh.text = "0%";
        shotValue = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            shotValue = 0;
        }

        if(Input.GetMouseButton(0))
        {
            shotValue = playerController.GetComponent<PlayerController>().getShotStrength() / playerController.GetComponent<PlayerController>().getMaxShot() * 100;
            textMesh.text = shotValue.ToString("0") + "%";
        }
        

	}
}
