using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefstemp : MonoBehaviour {
	public static string language;
	public static int width;
	public static string quality;
	// Use this for initialization
	void Start () {
		language = prefs.language;
		width = prefs.width;
		quality = prefs.quality;
	}

}
