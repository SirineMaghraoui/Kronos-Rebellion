using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setprefs : MonoBehaviour {
	int width;
	string quality;
	// Use this for initialization
	void Start () {
		width = prefs.width;
		quality = prefs.quality;
		if (width == 1024) {
			Screen.SetResolution (1024, 768, true);
		} else if (width == 1280) {
			Screen.SetResolution (1280, 768, true);
		} else {
			Screen.SetResolution (1366, 768, true);
		}

		if (quality == "low") {
			QualitySettings.SetQualityLevel (0);
		} else if (quality == "medium") {
			QualitySettings.SetQualityLevel (2);
		} else {
			QualitySettings.SetQualityLevel (5);
		}
		//yield return new WaitForSeconds (1);
		this.GetComponent<setprefs> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
