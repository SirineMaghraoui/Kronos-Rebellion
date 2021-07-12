using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//gun
		Quaternion newRotation = Quaternion.identity;
		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, .05f);
		this.enabled = false;
	}
}
