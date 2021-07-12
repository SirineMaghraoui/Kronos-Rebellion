using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playMode : MonoBehaviour{

	public static bool mode;
	public GameObject wheel_1;
	public GameObject wheel_2;
	public GameObject wheel_3;
	public GameObject wheel_4;

	//variables de mode defense
	float car_speed = 18.0f;
	float angle_speed = 40.0f;
	public static bool isMovingForward;
	public static bool isMovingBackward;

	float health;
	bool ok;

	Rigidbody rig;

	void Start (){ 
		health=car_health.health;
		mode = false;
		Cursor.visible = false;
		rig = GetComponent<Rigidbody> ();
	}

	void Update (){ 

		if (!mode && health>0){
			driving ();
			}
			
		// changer entre modes: attack et defence
		if(mode){
			if (Input.GetKeyDown (KeyCode.M)){
				mode = false;
			}
		}

		if (!mode) {
			if (Input.GetKey (KeyCode.N)){
				mode = true;
			}
		}

	}

	void driving(){
		if (isMovingForward) {
			transform.Translate (Vector3.forward * car_speed * Time.deltaTime); 
			wheelRotX (wheel_1.transform.GetChild (0), true);
			wheelRotX (wheel_2.transform.GetChild (0), true);
			wheelRotX (wheel_3.transform.GetChild (0), true);
			wheelRotX (wheel_4.transform.GetChild (0), true);
		} 

		if (isMovingBackward) {
			transform.Translate (Vector3.forward * car_speed * Time.deltaTime * (-1.0f)); 
			wheelRotX (wheel_1.transform.GetChild (0), false);
			wheelRotX (wheel_2.transform.GetChild (0), false);
			wheelRotX (wheel_3.transform.GetChild (0), false);
			wheelRotX (wheel_4.transform.GetChild (0), false);
		} 


		if (Input.GetKey (KeyCode.Z)) {
			isMovingForward = true;
		}
		if (Input.GetKey (KeyCode.S)) {
			isMovingBackward = true;
		}


		if (!Input.GetKey (KeyCode.Z)) {
			isMovingForward = false;
		}

		if (!Input.GetKey (KeyCode.S)) {
			isMovingBackward = false;
		}

		if (Input.GetKey (KeyCode.Z) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.Q)) {
			resetRot (wheel_1,this.gameObject,0.03f);
			resetRot (wheel_2,this.gameObject,0.03f);
			resetRot (wheel_3,this.gameObject,0.03f);
			resetRot (wheel_4,this.gameObject,0.03f);

		}

		if (Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.Q)) {
			resetRot (wheel_1,this.gameObject,0.03f);
			resetRot (wheel_2,this.gameObject,0.03f);
			resetRot (wheel_3,this.gameObject,0.03f);
			resetRot (wheel_4,this.gameObject,0.03f);

		}



		if (Input.GetKey (KeyCode.D) &&  Input.GetKey (KeyCode.Z)) {
			transform.Rotate (Vector3.up * angle_speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.Q) && Input.GetKey (KeyCode.Z)) {
			transform.Rotate (Vector3.down * angle_speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D) &&  Input.GetKey (KeyCode.S)) {
			transform.Rotate (Vector3.up * angle_speed * Time.deltaTime*(-1.0f));
		}

		if (Input.GetKey (KeyCode.Q) && Input.GetKey (KeyCode.S)) {
			transform.Rotate (Vector3.down * angle_speed * Time.deltaTime*(-1.0f));
		}


		wheelRotY2 (wheel_1);
		wheelRotY2 (wheel_2);
		wheelRotY2 (wheel_3);
		wheelRotY2 (wheel_4);
	}


	public static void resetRot(GameObject GO,GameObject GO1, float smoothness){
		GO.transform.rotation=Quaternion.Slerp(GO.transform.rotation,GO1.transform.rotation,smoothness);
	}
		
	void wheelRotX(Transform GO, bool ok){
		if (ok) {
			GO.transform.Rotate (5, 0, 0);
		} else {
			GO.transform.Rotate (-5,0,0);
		}
	}

	void wheelRotY2 (GameObject GO){
		float eul = GO.transform.localEulerAngles.y;
		if (Input.GetKey (KeyCode.D)) {
			if (eul >= 345 || eul < 15) {
				GO.transform.Rotate(0,1.0f,0);
			}
		}

		if (Input.GetKey (KeyCode.Q)) {
			if(eul<=16 || eul>345){	
				GO.transform.Rotate(0,-1.0f,0);
			}
		}
	}		
}