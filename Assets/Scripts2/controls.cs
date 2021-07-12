using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {
	Animator anim;
	public static bool isInLab;
	public  bool isIdling;
	public  bool isWalking;
	public  bool isRunning;
	public  bool isWalkingRight;
	public  bool isWalkingLeft;
	public  bool isRunningRight;
	public  bool isRunningLeft;

	bool attackMode;
	int layer;

	// Use this for initialization
	void Start () {
		
		attackMode= false;
		//layer = 0;
		anim = GetComponent<Animator> ();
		isIdling = true;
		isWalking = false;
		isRunning = false;
		isWalkingRight = false;
		isWalkingLeft = false;
		isRunningRight=false;
		isRunningLeft=false;

		anim.SetInteger ("run",-1);
		anim.SetInteger ("walkRight",-1);
		anim.SetInteger ("walkLeft",-1);
		anim.SetInteger ("runRight",-1);
		anim.SetInteger ("runLeft",-1);
	}
	
	// Update is called once per frame
	void Update () {
		walk ();
		run ();
	}
		
	void walk(){

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
			anim.SetInteger ("run_runRight_runLeft",-1);
			isIdling = true;
			isWalking = false;
			isRunning = false;
			isWalkingRight = false;
			isWalkingLeft = false;
			isRunningRight=false;
			isRunningLeft=false;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("walk")) {
			isIdling = false;
			isWalking = true;
			isRunning = false;
			isWalkingRight = false;
			isWalkingLeft = false;
			isRunningRight=false;
			isRunningLeft=false;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("walkRight")) {
			transform.Rotate (0,1,0);
			isIdling = false;
			isWalking = false;
			isRunning = false;
			isWalkingRight = true;
			isWalkingLeft = false;
			isRunningRight=false;
			isRunningLeft=false;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("walkLeft")) {
			transform.Rotate (0,-1,0);
			isIdling = false;
			isWalking = false;
			isRunning = false;
			isWalkingRight = false;
			isWalkingLeft = true;
			isRunningRight=false;
			isRunningLeft=false;
		}
			
		if (Input.GetKey (KeyCode.Z) ) {
			anim.SetBool ("walk",true);

		}

		if (Input.GetKeyUp (KeyCode.Z) ) {
			anim.SetBool ("walk",false);
		}

		if (Input.GetKey (KeyCode.D)) {
			anim.SetInteger ("walkRight", 0);
		}

		if (Input.GetKeyUp (KeyCode.D) && isWalking) {
			anim.SetInteger ("walkRight", 1);
		}

		if (Input.GetKeyUp (KeyCode.D) && !isWalking) {
			anim.SetInteger ("walkRight", 2);
		}

		if (Input.GetKey (KeyCode.Q)) {
			anim.SetInteger ("walkLeft", 0);
		}

		if (Input.GetKeyUp (KeyCode.Q) && isWalking) {
			anim.SetInteger ("walkLeft", 1);
		}

		if (Input.GetKeyUp (KeyCode.Q) && !isWalking) {
			anim.SetInteger ("walkLeft", 2);
		}




	}
		
	void run(){
		
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("run")) {
			isIdling = false;
			isWalking = false;
			isRunning = true;
			isWalkingRight = false;
			isWalkingLeft = false;
			isRunningRight=false;
			isRunningLeft=false;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("runRight")) {
			transform.Rotate (0,2,0);
			isIdling = false;
			isWalking = false;
			isRunning = false;
			isWalkingRight = false;
			isWalkingLeft = false;
			isRunningRight=true;
			isRunningLeft=false;
		}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("runLeft")) {
			transform.Rotate (0,-2,0);
			isIdling = false;
			isWalking = false;
			isRunning = false;
			isWalkingRight = false;
			isWalkingLeft = false;
			isRunningRight=false;
			isRunningLeft=true;
		}
		//running forward

		if (isWalking && Input.GetKey (KeyCode.LeftShift)) {
			anim.SetInteger ("run",0);
		}

			if (anim.GetCurrentAnimatorStateInfo (layer).IsName ("run")) {
			if (anim.GetBool ("walk") && Input.GetKeyUp (KeyCode.LeftShift)) {
				anim.SetInteger ("run", 1);
			}

			if (Input.GetKeyUp (KeyCode.Z)) {
				anim.SetInteger ("run", 2);
			}

			if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("run_runRight_runLeft",0);
			}

			if (Input.GetKey (KeyCode.Q) && Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("run_runRight_runLeft",2);
			}
		}
			

		//running right

			if (anim.GetCurrentAnimatorStateInfo (layer).IsName ("runRight")) {
			if (Input.GetKey (KeyCode.Z) && Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("run_runRight_runLeft",1);
			}

			if (Input.GetKey (KeyCode.Q) && Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("run_runRight_runLeft",4);
			}

		}

			if (anim.GetCurrentAnimatorStateInfo (layer).IsName ("runLeft")) {
			if (Input.GetKey (KeyCode.Z) && Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("run_runRight_runLeft",3);
			}

			if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("run_runRight_runLeft",5);
			}
		}

		if (isWalkingRight && Input.GetKey (KeyCode.LeftShift)) {
			anim.SetInteger ("runRight", 0);
		}
			
		if (isWalkingRight && Input.GetKeyUp(KeyCode.LeftShift)) {
			anim.SetInteger ("runRight", 1);
		}

		if (!isWalkingRight && Input.GetKeyUp(KeyCode.LeftShift)) {
			anim.SetInteger ("runRight", 2);
		}

		//running left

		if (isWalkingLeft && Input.GetKey (KeyCode.LeftShift)) {
			anim.SetInteger ("runLeft", 0);
		}

		if (isWalkingLeft && Input.GetKeyUp(KeyCode.LeftShift)) {
			anim.SetInteger ("runLeft", 1);
		}

		if (!isWalkingLeft && Input.GetKeyUp(KeyCode.LeftShift)) {
			anim.SetInteger ("runLeft", 2);
		}	
	}
}
