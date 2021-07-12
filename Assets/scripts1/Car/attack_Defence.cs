using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class attack_Defence : MonoBehaviour {
	
	public static RaycastHit hit;
	public static  bool onAim;

	public Sprite black_aim;
	public Sprite red_aim;
	public Image scope;

	public GameObject up;
	public GameObject down;
	public GameObject right;
	public GameObject left;

	Animator animUp;
	Animator animDown;
	Animator animRight;
	Animator animLeft;

	public float zoomSensitivity = 30.0f;
	public float zoomSpeed = 6.0f;
	public float zoomMin = 30.0f;
	public float zoomMax = 80.0f;
	private float zoom;

	private float x = 0.0f;
	private float y = 0.0f;
	public GameObject gun;
	float speed = 120.0f;
	private Vector3 angle;
	private Vector3 camHeight;


	// Use this for initialization
	void Start () {

		//relative au mode attaque
		angle = Camera.main.transform.eulerAngles;
		x = angle.y;
		y = angle.x;

		camHeight = new Vector3 (0, 0.5f, 0);

		zoom = Camera.main.GetComponent<Camera> ().fieldOfView;
		animUp = up.GetComponent<Animator> ();
		animDown = down.GetComponent<Animator> (); 
		animRight = right.GetComponent<Animator> ();
		animLeft = left.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (playMode.mode && car_health.health>0) {
			//positionner la camera derriére le pistolet 
			Vector3 camPos = new Vector3 (gun.transform.position.x, gun.transform.position.y+.15f + camHeight.y, gun.transform.position.z-.6f);
			Camera.main.transform.position = camPos;

			gunControl ();
			zooming();

			scope.gameObject.SetActive (true);
			up.SetActive (true);
			down.SetActive (true);
			right.SetActive (true);
			left.SetActive (true);

			if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000)){  
				if (hit.transform.tag == "drone") { 
					onAim = true;						
				} else {
					onAim = false;
				}
			} 

			manageScope ();

		} else if(!playMode.mode && car_health.health>0) {
			scope.gameObject.SetActive (false);
			playMode.resetRot (gun, this.gameObject,.015f);
		}
	}

	void zooming(){
		zoom -= Input.GetAxis ("Mouse ScrollWheel") * zoomSensitivity;
		zoom = Mathf.Clamp (zoom, zoomMin, zoomMax);
		Camera.main.GetComponent<Camera> ().fieldOfView = Mathf.Lerp (Camera.main.GetComponent<Camera> ().fieldOfView, zoom, Time.deltaTime * zoomSpeed);
	}


	void gunControl(){
		x += Input.GetAxis ("Mouse X") * speed * Time.deltaTime;
		y -= Input.GetAxis ("Mouse Y") * speed * Time.deltaTime;
		y = camFollow.ClampAngle (y, -30, 10);
		Camera.main.transform.rotation = Quaternion.Euler (y, x, 0);
		gun.transform.rotation = Quaternion.Euler (y, x, 0);
	}

	void manageScope(){
		if (playMode.mode) {
			if (onAim) {
				if (Input.GetMouseButton (0)) {
					up.SetActive (false);
					down.SetActive (false);
					right.SetActive (false);
					left.SetActive (false);

					animUp.SetBool ("on", false);
					animDown.SetBool ("on", false);
					animRight.SetBool ("on", false);
					animLeft.SetBool ("on", false);

					scope.GetComponent<Image>().sprite=red_aim;

				} else {

					up.SetActive (true);
					down.SetActive (true);
					right.SetActive (true);
					left.SetActive (true);

					animUp.SetBool ("on", true);
					animDown.SetBool ("on", true);
					animRight.SetBool ("on", true);
					animLeft.SetBool ("on", true);

					scope.GetComponent<Image>().sprite=black_aim;	
				}
			}else{

				up.SetActive (false);
				down.SetActive (false);
				right.SetActive (false);
				left.SetActive (false);

				animUp.SetBool ("on", false);
				animDown.SetBool ("on", false);
				animRight.SetBool ("on", false);
				animLeft.SetBool ("on", false);

				scope.GetComponent<Image>().sprite=black_aim;
			}
		}
	}


	void manageAgent(){
		
	}


}
