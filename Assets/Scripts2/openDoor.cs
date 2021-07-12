using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour {
	Animator anim;
	private bool test=false;
	void Start(){
		anim = GetComponent<Animator> ();
	}
	void FixedUpdate()
	{


		if(test)
		{
			
				if (!anim.GetBool ("state"))
			    {
					if (Input.GetKeyDown (KeyCode.E)) 
					{
						anim.SetBool ("state", true);
					}
				} 

				else {
					if (Input.GetKeyDown(KeyCode.E)) 
					{
						anim.SetBool ("state", false);
					}
				}

			}


	}
	void OnTriggerEnter(Collider other)
	{ 
		test = true;
	}
	void OnTriggerExit(Collider other)
	{
		test = false;
	}


}
