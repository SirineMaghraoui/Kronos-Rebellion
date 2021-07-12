using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followKronos : MonoBehaviour {

	private bool isInLab;
	public GameObject initial;
	private float rotSpeed=1.5f;
	Transform target;

	private Animator anim;
	private RaycastHit hit;


	void Start() {

		target = GameObject.FindWithTag("Player").transform;
	
		anim = GetComponent<Animator>();
		anim.SetBool ("walk",false);
		anim.SetBool ("run",false);
		anim.SetBool ("idle",false);
	}

	void FixedUpdate() {
		float distance;
		isInLab = controls1.inLab;
		if (!isInLab) {
			distance= Vector3.Distance(transform.position, target.transform.position);	
			Debug.Log (distance);
			Vector3 dir = target.position - transform.position;
			dir.y = 0;	
			Quaternion rot = Quaternion.LookRotation (dir);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, rotSpeed * Time.deltaTime);
			if (distance > 2.0f) {

				if (controls1.isWalking) {
					transform.LookAt (target.position);
					anim.SetBool ("idle", false);
					anim.SetBool ("walk", true);
				} else
					if (controls1.isRunning || controls1.isRunningLeft || controls1.isRunningRight) {
					anim.SetBool ("idle", false);
					anim.SetBool ("walk", false);
					anim.SetBool ("run", true);
					transform.LookAt (target.position);
				}

			}

			else {
				if (controls1.isIdling && distance<=1.0f) {
					anim.SetBool ("walk",false);
					anim.SetBool ("idle", true);
					anim.SetBool ("run", false);
				} 
				else 
					if(controls1.isWalking  && distance<=1.0f)
				{
						anim.SetBool ("idle", false);
						anim.SetBool ("walk", true);
					
						transform.Translate(Vector3.forward*-1*Time.deltaTime);
				}


			}

		} else{
			anim.SetBool ("walk", false);
			anim.SetBool ("run", false);
			anim.SetBool ("idle", true);
			distance= Vector3.Distance(transform.position, initial.transform.position);	


			if (distance > 0.5) {
				Vector3 dir = initial.transform.position - transform.position;
				dir.y = 0 ;	
				Quaternion rot = Quaternion.LookRotation (dir);
				transform.rotation = Quaternion.Slerp (transform.rotation, rot, rotSpeed * Time.deltaTime);
				anim.SetBool ("idle", false);
				anim.SetBool ("walk", true);
				anim.SetBool ("run", false);


			} 
			else {
				
				Debug.Log (transform.eulerAngles.y);
				if (tag == "AS1") {
					if (transform.eulerAngles.y > 240) {
						transform.Rotate (0, -.5f, 0);
					}
				} else {
					if (transform.eulerAngles.y <300) {
						transform.Rotate (0, .5f, 0);
					}
				}



			}


			
	}
	}

}
