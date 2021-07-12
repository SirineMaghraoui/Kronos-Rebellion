using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTurn : MonoBehaviour {

	Animator anim;
	bool ok;
	public GameObject player;
	// Use this for initialization
	void Start () {
		anim = player.GetComponent<Animator> ();
		ok = false;
	}
	
	// Update is called once per frame
	void Update () {

		if ((anim.GetCurrentAnimatorStateInfo (0).IsName ("walk") || anim.GetCurrentAnimatorStateInfo (0).IsName ("run")) && Input.GetKey (KeyCode.Z)) {
		/*	if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
				if ((this.transform.rotation.eulerAngles.y > 0) && this.transform.rotation.eulerAngles.y > player.transform.rotation.eulerAngles.y) {
					player.transform.Rotate (0, 300 * Time.deltaTime, 0);
					ok = true;
				}
			}*/

			//if (ok) {
				player.transform.localEulerAngles = new Vector3 (player.transform.localEulerAngles.x, transform.localEulerAngles.y, player.transform.localEulerAngles.z);
				anim.SetInteger ("direction", 1);

			//}

		}
	}


}
