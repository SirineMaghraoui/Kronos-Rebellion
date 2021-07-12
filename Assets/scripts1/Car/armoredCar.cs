using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
public class armoredCar : MonoBehaviour
{
	public  armoredCarData carData = new armoredCarData();
	void Start()
	{
		LoadData ();
	}
	public void storeData()
	{   //store position data 
		
		carData.pos_x =transform.position.x;
		carData.pos_y =transform.position.y;
		carData.pos_z=transform.position.z;
		carData.carTarget = autodrive.i;
		//store rotation data 

		carData.rot_x =transform.eulerAngles.x;
		carData.rot_y =transform.eulerAngles.y;
		carData.rot_z=transform.eulerAngles.z;

		//store health data 
		carData.shield = car_health.shield;
		carData.health=car_health.health;

		//store mode data 
		//carData.mode =playMode.mode;

	}
	void OnEnable()
	{   

		saveData.OnBeforeSave += delegate {
			storeData ();
		};

		saveData.OnBeforeSave += delegate {
			saveData.AddcarData (carData);
		};


	}
	void LoadData()
	{

		if( System.IO.File.Exists(gameController.dataPath))
		{


			armoredCarData data = saveData.Loadobject (gameController.dataPath);
			transform.position = new Vector3 (data.pos_x,data.pos_y,data.pos_z);
			transform.eulerAngles = new Vector3 (data.rot_x,data.rot_y,data.rot_z);
			//playMode.mode = data.mode;
			car_health.shield = data.shield;
			car_health.health = data.health;
			autodrive.i = data.carTarget;

		}
	}
}

public class armoredCarData 
{
		
		public float pos_x;

		
		public float pos_y;


		public float pos_z;

    	public float rot_x;


	    public float rot_y;


	    public float rot_z;


		public float health;


	    public  float  shield ;


	    //public bool mode;

	    public int carTarget;
}
