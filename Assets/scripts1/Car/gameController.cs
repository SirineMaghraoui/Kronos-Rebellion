using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gameController : MonoBehaviour {
	
	[Header("save file path")]

	public static string dataPath;


	void Awake()
	{
		dataPath = System.IO.Path.Combine (Application.dataPath, "Resources/armoredCar.xml");

	}


	void Start()
	{
		InvokeRepeating ("callCarsave",15,15);


	}



	 void callCarsave()
	{
		
		saveData.Save (dataPath,saveData.armCar.carData);


	}





	}

    
