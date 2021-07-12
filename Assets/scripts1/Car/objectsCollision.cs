using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsCollision : MonoBehaviour {
	public static bool col;
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "object") {
			col = true;
		}	
	}

	void OnCollisionExit(Collision other){
		if (other.gameObject.tag == "object") {
			col = false;
		}	
	}
}
