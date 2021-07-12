using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour {

	public float distance=10.0f;
	private Vector3 angle;
	public static float x=0.0f;
	public static float y=0.0f;
	private float camRotspeed = 100.0f;
	public float max_y=20.0f;
	public float min_y=0.0f;
	public float camH;
	private Vector3 camHeight;

	void Start () {
		
	
		camHeight = new Vector3(0,camH,0);
		angle = this.transform.eulerAngles;
		x = angle.y;
		y = angle.x;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		x += Input.GetAxis ("Mouse X") * camRotspeed * Time.deltaTime;
		y -= Input.GetAxis ("Mouse Y") * camRotspeed * Time.deltaTime;
		if (!playMode.mode) {
			y = ClampAngle (y, min_y, max_y);
			Quaternion rotation = Quaternion.Euler (y, x, 0);
			Vector3 negDistance = new Vector3 (0.0f, 0.0f, -distance);
			Camera.main.transform.rotation = rotation;
			Vector3 position = rotation * negDistance + transform.position + camHeight;
			Camera.main.transform.position = position;



		}
	}
		

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}


}
