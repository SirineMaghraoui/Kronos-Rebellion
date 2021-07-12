using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer_1 : MonoBehaviour {

	public GameObject item;
	bool test;
	public static bool DrawerIsEmpty;
	public static bool DrawerIsOpen;
	public static bool accumulator=false;
	public Material normal;
	public Material highlighted;
	void Start () {
		test = false;
		if(!System.IO.File.Exists(levelOneController.obj_state_DataPath))
		{
			DrawerIsOpen = false;
			DrawerIsEmpty = false;
		}


	}


	void Update () {
		if (test) {
			
				Animator anim = this.GetComponent<Animator> ();

				if (Input.GetKeyDown (KeyCode.E)) {
					if (DrawerIsOpen == false && DrawerIsEmpty == false) {
						DrawerIsOpen = true;
						anim.SetBool ("open", true);
					} else if (DrawerIsOpen == true && DrawerIsEmpty == false) {

						Destroy (item);
						accumulator = true;
						DrawerIsEmpty = true;


					} else if (DrawerIsOpen == false && DrawerIsEmpty == true) {
						DrawerIsOpen = true;
						anim.SetBool ("open", true);
					} else if (DrawerIsOpen == true && DrawerIsEmpty == true) {
						DrawerIsOpen = false;
						anim.SetBool ("open", false);
					}
				 


			}
		}

	}

	void OnTriggerEnter(){
		test = true;
		GetComponent<Renderer> ().material = highlighted;

	}

	void OnTriggerExit()
	{
		test = false;
		GetComponent<Renderer> ().material = normal;

	}
}
