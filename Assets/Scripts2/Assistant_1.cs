using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Assistant_1 : MonoBehaviour 
{
	public Assistant_1_Data assistant_data = new Assistant_1_Data ();


	void Start()
	{
		loadData ();
	}
	public void storeData()
	{  


			// store position
		assistant_data.pos_x = transform.position.x;
		assistant_data.pos_y = transform.position.y;
		assistant_data.pos_z = transform.position.z;
		//store rotation 
		assistant_data.rot_x= transform.eulerAngles.x;
		assistant_data.rot_y = transform.eulerAngles.y;
		assistant_data.rot_y = transform.eulerAngles.z;
			//store health

		


	}
	public void loadData()
	{
		
			if(System.IO.File.Exists(levelOneController.assistant_1_DataPath))
		{  
			    Assistant_1_Data assistant_d = saveData.loadAssistantData_1 (levelOneController.assistant_1_DataPath);
				transform.position = new Vector3 (assistant_d.pos_x,assistant_d.pos_y,assistant_d.pos_z);
				transform.eulerAngles = new Vector3 (assistant_d.rot_x,assistant_d.rot_y,assistant_d.rot_z);
		}
			



	}
	void OnEnable()
	{
		saveData.OnBeforeSave += delegate
		{
			storeData();
		};
		saveData.OnBeforeSave += delegate
		{
			saveData.addAssistantData_1(assistant_data);
		};
	}

}
public class Assistant_1_Data
{


	public float pos_x;

	public float pos_y;

	public float pos_z;

	public float rot_x;

	public float rot_y;

	public float rot_z;

	//public float health;


}