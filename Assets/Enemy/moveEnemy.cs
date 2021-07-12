using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
	[Header("Drone 1 gun")]
	public GameObject gun;
	public Transform launcher1;
	public Transform launcher2;

	[Header("Drone 2 gun")]
	public Transform launcher0;

	[Header("Drone1 bullet")]
	public GameObject drone1_bullet;

	[Header("Drone2 bullet")]
	public GameObject drone2_bullet;

	[Header("Particle system")]
	public Transform flame;

	Animator anim;
	private Transform target;
	private Vector3 Enemy_position;
	private RaycastHit hit;
	private float distance;
	private float min_distance;
	private float speed = 150.0f;
	private int bullet_speed = 10000;
	private float timer;


	public bool onAim;
	private int health;

	void Start (){
		//onAim=false;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		if (name == "drone1(Clone)") {
			anim = gun.GetComponent<Animator> ();

		}

		timer = 4.10f;
		StartCoroutine ("shootTarget");

	}

	void FixedUpdate (){ 
		health = GetComponent<Enemy_health> ().health;
		transform.LookAt (target);
		distance = Vector3.Distance (transform.position, target.position);
		min_distance = Random.Range (35, 60);
		if (distance > min_distance) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}



		if (name == "drone1(Clone)") {
			if (health>0 && Physics.Raycast (launcher1.position, launcher1.transform.forward*1000, out hit, 1000) && Physics.Raycast (launcher2.position, launcher2.forward*1000, out hit, 1000)) {
				if (hit.transform.tag == "Player") {  
					onAim = true;	
				} 

			}
		} else {	
			if (health>0 && Physics.Raycast (launcher0.transform.position, launcher0.transform.forward*100, out hit, 100)) {
				if (hit.transform.tag == "Player") {   
					onAim = true;
				}
			}
		}

	}


	IEnumerator shootTarget (){
		while(true){
			if (onAim && health>0) {
				
				if (name == "drone1(Clone)") {

				if (health > 0 && !anim.GetBool ("shoot") && onAim) {
						anim.SetBool ("shoot", true);
					}
				
				} 

				if (timer > 0) {

					if (name == "drone1(Clone)") {
						// first bullet+particle
						GameObject bull_1 = Instantiate (drone1_bullet, launcher1.transform.position, launcher1.transform.rotation);
						bull_1.GetComponent<Rigidbody> ().AddForce (launcher1.transform.forward * bullet_speed);

						Transform fire_effect_1 = Instantiate (flame, launcher1.transform.position, launcher1.transform.rotation);

						Destroy (fire_effect_1.gameObject, 0.01f);
						Destroy (bull_1, 1.5f);

						//second bullet+particle
						GameObject bull_2 = Instantiate (drone1_bullet, launcher2.transform.position, launcher2.transform.rotation);
						bull_2.GetComponent<Rigidbody> ().AddForce (launcher2.transform.forward * bullet_speed);

						Transform fire_effect_2 = Instantiate (flame, launcher2.transform.position, launcher2.transform.rotation);

						Destroy (fire_effect_2.gameObject, 0.01f);
						Destroy (bull_2, 1.5f);

					} else {

						//bullet+particle
						GameObject bull_0 = Instantiate (drone2_bullet, launcher0.transform.position, launcher0.transform.rotation);
						bull_0.GetComponent<Rigidbody> ().AddForce (launcher0.transform.forward * bullet_speed);

						Transform fire_effect_0 = Instantiate (flame, launcher0.transform.position, launcher0.transform.rotation);
						fire_effect_0.transform.position = launcher0.transform.position;

						Destroy (fire_effect_0.gameObject, 0.1f);
						Destroy (bull_0, 1.5f);
					}


					timer = timer - Time.deltaTime;	
				} else {
					yield return new WaitForSeconds (.9f);
					timer = 4.1f;
				}
			}
			yield return new WaitForSeconds (0);
		}
	}
}

