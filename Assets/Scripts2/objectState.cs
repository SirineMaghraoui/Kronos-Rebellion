using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectState : MonoBehaviour
{
	public objectState_Data obj_state=new objectState_Data();
	public GameObject drawer;
	public GameObject lab_1_Door;
	public GameObject lab_2_Door;
	public GameObject serv_1_Door;
	public GameObject serv_2_Door;
	public GameObject hall_Door;
	public GameObject mainhall_Door;
	public GameObject sh_Door;
	public GameObject square_Door;
	void Awake()
	{
		loadObjectData ();
	}
	public void storeData()
	{   //store case data
		
			obj_state.caseIsopen=highlight_collect.CaseIsOpen;
		
			obj_state.caseIsempty=highlight_collect.CaseIsEmpty;


		// store drawer_1 data


			obj_state.drawerIsempty_1 = drawer_1.DrawerIsEmpty;
			obj_state.drawerIsopen_1 = drawer_1.DrawerIsOpen;


		//store drawer_2 data

			obj_state.drawerIsempty_2 = drawer_2.DrawerIsEmpty;
			obj_state.drawerIsopen_2 = drawer_2.DrawerIsOpen;

		//store doors data 
		obj_state.lab_1_Door_state= lab_1_Door.GetComponent<Animator>().GetBool("state");
		obj_state.lab_2_Door_state= lab_2_Door.GetComponent<Animator>().GetBool("state");
		obj_state.serv_1_Door_state= serv_1_Door.GetComponent<Animator>().GetBool("state");
		obj_state.serv_2_Door_state= serv_2_Door.GetComponent<Animator>().GetBool("state");
		obj_state.shDoor_state= sh_Door.GetComponent<Animator>().GetBool("state");
		obj_state.mainhallDoor_state=mainhall_Door.GetComponent<Animator>().GetBool("state");
		obj_state.hallDoor_state=hall_Door.GetComponent<Animator>().GetBool("state");
		obj_state.squareDoor_state=square_Door.GetComponent<Animator>().GetBool("state");

			
	}
	public void loadObjectData()
	{
		if(System.IO.File.Exists(levelOneController.obj_state_DataPath))
		{   objectState_Data data = saveData.loadobjectstateData (levelOneController.obj_state_DataPath);
			
			//load case data 
			if(name=="gun case 1")
			{  Animator anim = GetComponent<Animator> ();
				highlight_collect.CaseIsOpen=data.caseIsopen;
				highlight_collect.CaseIsEmpty=data.caseIsempty;
				if(data.caseIsopen)
				{   anim.SetBool ("open", true);
					
				}
			}
			//load drawer_2 data 

			if(tag=="drawer_2")
			
			{  
				   drawer_1.DrawerIsOpen = data.drawerIsopen_1;
				
					drawer_1.DrawerIsEmpty = data.drawerIsempty_1;
				
					Animator anim = GetComponent<Animator> ();
				
					if (data.drawerIsopen_1) 
				
					{
					
						anim.SetBool ("open", true);
				
					}
			
				}

			//load drawer_1 data
				
			drawer_2.DrawerIsOpen=data.drawerIsopen_2;
			drawer_2.DrawerIsEmpty = data.drawerIsempty_2;
			Animator animator = drawer.GetComponent<Animator> ();
				
				if(data.drawerIsopen_2)
				
					{
					
						animator.SetBool ("open", true);
				
					}
			// load doors data 
			lab_1_Door.GetComponent<Animator>().SetBool("state",data.lab_1_Door_state);
			lab_2_Door.GetComponent<Animator>().SetBool("state",data.lab_2_Door_state);
			serv_1_Door.GetComponent<Animator>().SetBool("state",data.serv_1_Door_state);
			serv_2_Door.GetComponent<Animator>().SetBool("state",data.serv_2_Door_state);
			square_Door.GetComponent<Animator>().SetBool("state",data.squareDoor_state);
			sh_Door.GetComponent<Animator>().SetBool("state",data.shDoor_state);
			hall_Door.GetComponent<Animator>().SetBool("state",data.hallDoor_state);
			mainhall_Door.GetComponent<Animator>().SetBool("state",data.mainhallDoor_state);



					
		}
	}
	void OnEnable()
	{

		saveData.OnBeforeSave += delegate {
			storeData();	
		};
		saveData.OnBeforeSave += delegate {
			saveData.addobjectstateData(obj_state);
		};
	}
	
}
public class objectState_Data
{
	//case

	public bool caseIsopen;
	public bool caseIsempty;

	//drawer_1
	public bool drawerIsopen_1;
	public bool drawerIsempty_1;
	//drawer_2
	public bool drawerIsopen_2;
	public bool drawerIsempty_2;

	//doors 
	public bool squareDoor_state;
	public bool mainhallDoor_state;
	public bool shDoor_state;
	public bool lab_1_Door_state;
	public bool lab_2_Door_state;
	public bool serv_1_Door_state;
	public bool serv_2_Door_state;
	public bool hallDoor_state;
}