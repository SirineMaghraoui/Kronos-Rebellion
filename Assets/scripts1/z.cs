using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z : MonoBehaviour {
	public GameObject x;
	void LateUpdate()
	{if (car_health.health > 0) {
			GameObject lunched_bullet = Instantiate (x,transform.position,transform.rotation);
			Destroy (lunched_bullet,1);
		}

	}
}
