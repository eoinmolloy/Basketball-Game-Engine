using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
	public GameObject ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			//same pos as launcher
			GameObject g = (GameObject)(Instantiate (ball, transform.position, Quaternion.identity));
		}
	}
}
