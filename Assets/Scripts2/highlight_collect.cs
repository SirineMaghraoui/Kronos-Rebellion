using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight_collect : MonoBehaviour {

	bool test;
	bool DrawerIsEmpty;
	bool DrawerIsOpen;
	public static bool CaseIsEmpty;
	public static bool CaseIsOpen;

	public GameObject stungun_item;
	public GameObject Case ;

	public Material normal;
	public Material highlighted;

	public Material normalUpperCase;
	public Material highlightedUpperCase;
	public Material normalLowerCase;
	public Material highlightedLowerCase;

	public static bool stungun=false;
	public static bool al_box=false;
	public static bool card=false;
	public static bool container_lead=false;

	void Start()
	{
		test = false;
		if (!System.IO.File.Exists (levelOneController.obj_state_DataPath))
		{
			//DrawerIsOpen = false;
			//DrawerIsEmpty = false;
			CaseIsEmpty = false;
			CaseIsOpen = false;
		}

	}

	void Update(){
		if (test) {

			if (tag == "collect")
			{
				if (Input.GetKeyDown (KeyCode.E))
				{ 
					if (this.gameObject.name == "card")
					{
						Destroy (this.gameObject);
						card = true;
					} else
						if (this.gameObject.name == "Al Box") 
					{
						Destroy (this.gameObject);
						al_box = true;
					} 
						else 
							
						if (this.gameObject.name == "container-lead")
					{
						Destroy (this.gameObject);
						container_lead = true;
					} 
						
				}
			}


		else
			
			if (tag == "case")
			{
				Animator anim = Case.GetComponent<Animator> (); 
				if (Input.GetKeyDown (KeyCode.E)) {
					if (CaseIsOpen == false && CaseIsEmpty == false) {
						CaseIsOpen = true;
						anim.SetBool ("open", true);
					} 

					else if (CaseIsOpen == true && CaseIsEmpty == false) {
						Destroy (stungun_item);
						stungun = true;
						CaseIsEmpty = true;
					} 

					else if ( CaseIsOpen == false && CaseIsEmpty == true) {
						CaseIsOpen = true;
						anim.SetBool ("open", true);
					}
					else if (CaseIsOpen == true && CaseIsEmpty == true){
						CaseIsOpen = false;
						anim.SetBool ("open", false);
					}
				}

			}


}
}



	void OnTriggerEnter(){
		test = true;
		if (tag == "case") {
			Material[] mat1;
			Material[] mat2;
			mat1 = new Material [2];
			mat2 = new Material [2];
			mat1 [0] = highlightedUpperCase;
			mat1 [1] = normalUpperCase;
			mat2 [1] = highlightedLowerCase;
			mat2 [0] = normalLowerCase;
			GetComponent<Renderer> ().materials = mat2;
			Case.GetComponent<Renderer> ().materials = mat1;
		} 
		else {
			GetComponent<Renderer> ().material = highlighted;

		}
			
	}

	void OnTriggerExit(){
		test = false;
		if (tag == "case") {
			Material[] mat1;
			Material[] mat2;
			mat1 = new Material [2];
			mat2 = new Material [2];
			mat1 [0] = normalUpperCase;
			mat1 [1] = normalUpperCase;
			mat2 [0] = normalLowerCase;
			mat2 [1] = normalLowerCase;
			GetComponent<Renderer> ().materials = mat2;
			Case.GetComponent<Renderer> ().materials = mat1;
		} else 
		{
			GetComponent<Renderer> ().material = normal;
		}

}
}
