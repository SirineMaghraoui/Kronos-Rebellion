using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
public class kronos : MonoBehaviour {
	public Transform kr;
	public  kronos_Data kronos_data=new  kronos_Data();
	void Start ()
	{

		LoadData ();
	}

	void storeData()
	{   //store position data 
		
		kronos_data.pos_x =kr.position.x;
		kronos_data.pos_y = kr.position.y;
		kronos_data.pos_z = kr.position.z;

		//store rotation data 
		kronos_data.rot_x =kr.eulerAngles.x;
		kronos_data.rot_y =kr.eulerAngles.y;
		kronos_data.rot_z = kr.eulerAngles.z;

		Debug.Log (kr.position.z);
		// store health data 
		//kronos_data.health=

		// store collectable object data 
		kronos_data.al_Box=highlight_collect.al_box;
		kronos_data.card = highlight_collect.card;
		kronos_data.stungun = highlight_collect.stungun;
		kronos_data.container_lead = highlight_collect.container_lead;
		kronos_data.accumulator = drawer_1.accumulator;
		kronos_data.container_acid = drawer_2.container_acid;
	}
	void LoadData()
	{
		if(System.IO.File.Exists(levelOneController.kronosDataPath))
		{
			kronos_Data kr = saveData.loadKronosData (levelOneController.kronosDataPath);
			transform.position = new Vector3 (kr.pos_x,kr.pos_y,kr.pos_z);
			transform.eulerAngles = new Vector3 (kr.rot_x,kr.rot_y,kr.rot_z); 
			highlight_collect.al_box = kr.al_Box;
			highlight_collect.card = kr.card;
			highlight_collect.stungun = kr.stungun;
			highlight_collect.container_lead = kr.container_lead;
			drawer_2.container_acid = kr.container_acid;
			drawer_1.accumulator = kr.accumulator;
		}
	}

	void OnEnable()
	{
		saveData.OnBeforeSave += delegate {
			storeData ();

		};
		saveData.OnBeforeSave += delegate {
			saveData.addKronosData(kronos_data);
		};
	}


}
public class kronos_Data
{
	public float pos_x;

	public float pos_y;

	public float pos_z;

	public float rot_x;

	public float rot_y;

	public float rot_z;

	//public float health;

	public bool card ;

	public bool al_Box;

	public bool container_lead;

	public bool stungun;

	public bool container_acid;

	public bool accumulator;


}
