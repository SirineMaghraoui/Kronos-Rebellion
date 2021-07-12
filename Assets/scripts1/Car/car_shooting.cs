using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_shooting : MonoBehaviour {
	
	[Header("Car gun properties")]
	public Transform fire_point;
	public GameObject bullet;
	public Transform flame;
	private int speed = 10000;
	 
	void Update () {
		//if(playMode.mode){ 
			if (Input.GetMouseButton (0)){
				//instantiation de cartouche
				GameObject lunched_bullet = (GameObject)Instantiate (bullet,Camera.main.transform.position,Camera.main.transform.rotation);
				//instantiation de l'effet
				Transform fire_effect=Instantiate (flame,fire_point.transform.position,fire_point.transform.rotation);
				fire_effect.transform.position=fire_point.transform.position;
				Destroy (fire_effect.gameObject,0.1f);
				lunched_bullet.GetComponent<Rigidbody> ().AddForce (fire_point.forward*speed);
				Destroy (lunched_bullet, 5);
			}
		//}
	}
}
