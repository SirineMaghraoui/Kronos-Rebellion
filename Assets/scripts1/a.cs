using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Z)){
			transform.Translate (Vector3.forward*100* Time.deltaTime); 

		}
	}
}
