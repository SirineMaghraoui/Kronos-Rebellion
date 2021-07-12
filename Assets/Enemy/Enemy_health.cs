using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour

{   [Header("Armored car")]
	//public GameObject car;

	[Header("Drone 1 parts")]
	public GameObject mainBody1;
	public GameObject details;
	public GameObject upperVentillo;
	public GameObject ventillo;
	public GameObject gun1;

	[Header("Drone 2 parts")]
	public GameObject mainBody2;
	public GameObject wings;
	public GameObject vent;
	public GameObject gun2;

	[Header("Normal materials")]
	public Material normalMainBody;
	public Material normalDetails;

	[Header("Highlighted material")]
	public Material highlighted;

	[Header("Health")]
	public int health;

	[Header("Patcile systems")]
	public GameObject explosion;
	public GameObject smoke;

	public static bool enemy_dead = false;

	// drone 1 animators
	Animator anim1;
	Animator anim2;
	Animator anim3;

	//drone 2 animator;
	Animator anim4;

	void Start(){
		health = 200;
		if (name == "drone1(Clone)") {
			anim1 = ventillo.GetComponent<Animator> ();
			anim2 = upperVentillo.GetComponent<Animator> ();
			anim3 = gun1.GetComponent<Animator> ();	
		}
		else{
			anim4 = vent.GetComponent<Animator> ();
		}
			
		StartCoroutine ("louka");


	}
	void OnCollisionEnter(Collision col){
		
		if (col.transform.tag == "car_bullet") {
			health -= 10; 
			if (name == "drone1(Clone)") {
				changeMat (mainBody1, highlighted);
				changeMat (upperVentillo, highlighted);
				changeMat (ventillo, highlighted);
				changeMat (gun1, highlighted);
			}else {
				changeMat (mainBody2, highlighted);
				changeMat (wings, highlighted);
				changeMat (gun2,	 highlighted);
			}


			if (health <= 0) {
				if (name == "drone1(Clone)") {
					anim1.SetBool ("turn",false);
					anim2.SetBool ("turn",false);
					anim3.SetBool ("shoot",false);
				}
				else{
					anim4.SetBool ("turn",false);
				}
					
				/*GameObject explo=Instantiate (explosion,transform.position,transform.rotation) as GameObject;
				Destroy (explo,3);
				//transform.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
				transform.gameObject.GetComponent<Rigidbody> ().isKinematic=false;
				GameObject sm=Instantiate (smoke,transform.position,transform.rotation) as GameObject;
				Destroy (sm, 3);
				Destroy (this.gameObject,3);
				enemy_dead = true;*/

				if (car_health.shield < 50) {
					car_health.shield = car_health.shield + 50;
				} else{
					car_health.shield =100;;
				}
			}
		}
	}

	void OnCollisionExit(Collision col){
		
		if (col.transform.tag == "car_bullet") {
			if (name == "drone1(Clone)") {
				changeMat (mainBody1, normalMainBody);
				changeMat (upperVentillo, normalDetails);
				changeMat (ventillo, normalDetails);
				changeMat (gun1, normalDetails);
			}else {
				changeMat (mainBody2, normalMainBody);
				changeMat (wings, normalDetails);
				changeMat (gun2, normalDetails);
			}
		}
	}

	void changeMat(GameObject GO,Material mat){
			GO.GetComponent<Renderer> ().material = mat;
	}


	IEnumerator destroy(){
		while (true) {
			if (health == 0) {
				Debug.Log ("a");
				GameObject explo = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
				Destroy (explo, 7);
				transform.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;


			}			
			yield return new WaitForSeconds (0);
			//Debug.Log ("b");
			//yield return new WaitForSeconds(0.0f);
		
			/*GameObject explo=Instantiate (explosion,transform.position,transform.rotation) as GameObject;
		Destroy (explo, 7);
		yield return new WaitForSeconds (1.0f);
		transform.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;*/

		}



	}



	IEnumerator louka(){
		while (true) {
			if (health <= 0) {
				Debug.Log ("dd");
				GameObject explo = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
				Destroy (explo,7);
				transform.gameObject.GetComponent<Rigidbody> ().constraints &= ~RigidbodyConstraints.FreezeRotationY;
				Destroy (this.gameObject,1);


			}
			yield return new WaitForSeconds (10);
		}
	}
}
