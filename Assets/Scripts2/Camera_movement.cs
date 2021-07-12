using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour {
	public GameObject bullet;
	public Transform player_cam, center_point;
	public float distance, max_height, min_height, orbiting_speed, vertical_speed;
	float height;
	Vector3 dest;
	RaycastHit hit;

	void FixedUpdate () {
		center_point.position = gameObject.transform.position + new Vector3 (0, 1.5f, 0);
		center_point.eulerAngles += new Vector3 (0, Input.GetAxis ("Mouse X") * Time.deltaTime * orbiting_speed, 0);
		height += Input.GetAxis ("Mouse Y") * Time.deltaTime * -vertical_speed;
		height = Mathf.Clamp (height, min_height, max_height);

		dest = center_point.position + center_point.forward * -1 * distance + Vector3.up * height;
		if (Physics.Linecast (center_point.position, dest, out hit)) {
			if (hit.collider.CompareTag ("wall")) {
				player_cam.position = hit.point + hit.normal*.1f;
			}
		}
		player_cam.position = Vector3.Lerp (player_cam.position,dest,Time.deltaTime*10);
		player_cam.LookAt (center_point);
	}
}

