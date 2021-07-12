using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y : MonoBehaviour {

	void Update() {

		if (Input.GetKey (KeyCode.Z)) {
			wheelRotX (this.transform.GetChild(0));
		}
		wheelRotY2 (this.gameObject);
	}


	void wheelRotX(Transform GO){
		GO.transform.Rotate (5,0,0);
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
