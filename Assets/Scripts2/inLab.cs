using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inLab : MonoBehaviour {
	Transform player;
	void Start(){
		player = GameObject.FindWithTag("Player").transform;
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			controls1.inLab= true;

		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			controls1.inLab= false;		}
	}
}
