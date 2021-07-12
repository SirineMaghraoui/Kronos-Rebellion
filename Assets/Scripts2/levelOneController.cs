using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOneController : MonoBehaviour {

	public static string kronosDataPath;
	public static string assistant_1_DataPath;
	public static string assistant_2_DataPath;
	public static string obj_state_DataPath;
	void Awake()
	{
		kronosDataPath=System.IO.Path.Combine(Application.dataPath, "Resources/kronos.xml");
		assistant_1_DataPath=System.IO.Path.Combine(Application.dataPath, "Resources/assistant_1.xml");
		assistant_2_DataPath=System.IO.Path.Combine(Application.dataPath, "Resources/assistant_2.xml");
		obj_state_DataPath=System.IO.Path.Combine(Application.dataPath, "Resources/objectState.xml");

	}
	void Start ()
	{
		InvokeRepeating ("callKronosSave", 20,10);
		InvokeRepeating ("callAssistantSave", 20,10);
		InvokeRepeating ("callObjectStateSave", 20,10);
	}
	
	void callKronosSave()
	{
		saveData.saveKronos (kronosDataPath,saveData.kronos.kronos_data);

	}
	void callAssistantSave()
	{
		saveData.saveAssistant_1 (assistant_1_DataPath, saveData.assistant_1.assistant_data);
		saveData.saveAssistant_2 (assistant_2_DataPath, saveData.assistant_2.assistant_data);

	}
	void callObjectStateSave()
	{
		saveData.saveobjectState (obj_state_DataPath,saveData.obj_state.obj_state);
	}
}
