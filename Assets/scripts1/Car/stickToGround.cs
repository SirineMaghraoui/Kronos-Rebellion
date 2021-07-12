using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickToGround : MonoBehaviour {

	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -transform.up, out hit)) {
			var distanceToGround = hit.distance;
			transform.position = new Vector3 (transform.position.x,hit.point.y+distanceToGround,transform.position.z);
		}

	}
}
