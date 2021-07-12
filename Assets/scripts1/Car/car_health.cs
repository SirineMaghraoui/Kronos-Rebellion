using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_health : MonoBehaviour {
	
	public static float health=1000;
	public static float shield=000;
	private bool test=false;
	public GameObject whiteShockwave;
	public GameObject redShockwave;

	ParticleSystem Wps;
	ParticleSystem Rps;

	public GameObject explosion;
	public GameObject smokeUp1k;
	public GameObject smokeUp10k;
	public GameObject bullet_effect;

	Vector3 vect1k;
	Vector3 vect10k;

	void Start(){
		Wps = whiteShockwave.GetComponent<ParticleSystem> ();
		Rps = redShockwave.GetComponent<ParticleSystem> ();
		StartCoroutine("smoke");
	}

	void OnCollisionEnter(Collision col){  
		if (col.transform.tag == "drone1_bullet") {
			if (shield <=0 && health>0) {
				Vector3 v = col.contacts [0].point;
				GameObject clone =Instantiate (bullet_effect,v,Quaternion.identity);
				Destroy (clone,1);
			}
			if (shield > 25) {
				whiteShockwave.SetActive (true);
				Wps.Play ();
				shield -= 1.0f;
			} else if ((shield <= 25) && (shield>0)) {
				redShockwave.SetActive (true);
				Rps.Play ();
			}else if (shield ==0) {  
			     test = true;
			}
		}

		else if (col.transform.tag == "drone2_bullet") {  
			if (shield <=0 && health>0) {
				Vector3 v = col.contacts [0].point;
				GameObject clone =Instantiate (bullet_effect,v,Quaternion.identity);
				Destroy (clone,1);
			}
			if (shield > 25) {
				whiteShockwave.SetActive (true);
				Wps.Play ();
				shield -= 0.5f;
			} else if ((shield <= 25) && (shield>0)) {
				redShockwave.SetActive (true);
				Rps.Play ();
			}else if (shield ==0) {  
				test = true;
			}
		}

		if (test) { 
			if(health>0){
				health -= 2.5f; 
			}
			else if (health == 0){	
				GameObject explo=Instantiate (explosion,transform.position,transform.rotation) as GameObject;
				Destroy (explo,3);
				//Destroy (smokeUp1k);
			}
		}
	}


	IEnumerator smoke (){
		Vector3 vect1k = new Vector3 (transform.position.x,transform.position.y+2,transform.position.z-2.82f);
		Vector3 vect10k = new Vector3 (transform.position.x,transform.position.y+2,transform.position.z+1.2f);

		while (true) {
			if (health<=0) {		
				GameObject smUp1k =Instantiate (smokeUp1k,vect10k,Quaternion.identity) as GameObject;
				GameObject smUp10k =Instantiate (smokeUp1k,vect10k,Quaternion.identity) as GameObject;

				yield return new WaitForSeconds (9);
			}
			else{
				yield return new WaitForSeconds (0);
			}
		}
	}



}
