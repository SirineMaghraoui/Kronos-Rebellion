using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
public class saveData  {

	public delegate void SerializeAction();
	public static event SerializeAction OnBeforeSave;	
	public static kronos kronos=new kronos();
	public static Assistant_1 assistant_1=new Assistant_1();
	public static Assistant_2 assistant_2=new Assistant_2();
	public static objectState obj_state=new objectState();

	//save && load kronos data

	public static void saveKronos(string path , kronos_Data kr_data)
	{

		OnBeforeSave ();
		saveKronosData (path,kr_data);

	}


	public static void addKronosData(kronos_Data data)
	{
		
		kronos.kronos_data = data;		

	}
	public static void saveKronosData(string path,kronos_Data kr_data)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(kronos_Data));

		FileStream stream = new FileStream(path, FileMode.Create);

		serializer.Serialize(stream,kr_data);


		stream.Close();
	}
	public static kronos_Data loadKronosData(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(kronos_Data));

		FileStream stream = new FileStream(path, FileMode.Open);

		kronos_Data kr_data = serializer.Deserialize(stream) as kronos_Data;

		stream.Close();

		return kr_data;
	}

	// save && load assistant data 

	//asssistant_1

	public static void saveAssistant_1(string path , Assistant_1_Data as_data)
	{

		OnBeforeSave ();
		saveAssistantData_1 (path, as_data);

	}


	public static void addAssistantData_1(Assistant_1_Data data_1)
	{

		assistant_1.assistant_data = data_1;	


	}
	public static void saveAssistantData_1(string path,Assistant_1_Data as_data)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Assistant_1_Data));

		FileStream stream = new FileStream(path, FileMode.Create);

		serializer.Serialize(stream,as_data);


		stream.Close();
	}

	public static Assistant_1_Data loadAssistantData_1(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof( Assistant_1_Data ));

		FileStream stream = new FileStream(path, FileMode.Open);

		Assistant_1_Data  as_data = serializer.Deserialize(stream) as  Assistant_1_Data ;

		stream.Close();

		return as_data;
	}
	//asssistant_2

	public static void saveAssistant_2(string path , Assistant_2_Data as_data)
	{

		OnBeforeSave ();
		saveAssistantData_2 (path, as_data);

	}


	public static void addAssistantData_2(Assistant_2_Data data)
	{

		assistant_2.assistant_data = data;		

	}
	public static void saveAssistantData_2(string path,Assistant_2_Data as_data)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Assistant_2_Data));

		FileStream stream = new FileStream(path, FileMode.Create);

		serializer.Serialize(stream,as_data);


		stream.Close();
	}

	public static Assistant_2_Data loadAssistantData_2(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof( Assistant_2_Data ));

		FileStream stream = new FileStream(path, FileMode.Open);

		Assistant_2_Data  as_data = serializer.Deserialize(stream) as  Assistant_2_Data ;

		stream.Close();

		return as_data;
	}

	// save && load object state data 

	public static void saveobjectState(string path , objectState_Data obj)
	{

		OnBeforeSave ();
		saveobjectstateData(path, obj);

	}
	public static void addobjectstateData(objectState_Data data)
	{

		obj_state.obj_state = data;	

	}

	public static void saveobjectstateData(string path,objectState_Data obj)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(objectState_Data));

		FileStream stream = new FileStream(path, FileMode.Create);

		serializer.Serialize(stream,obj);


		stream.Close();
	}
	public static objectState_Data loadobjectstateData(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof( objectState_Data ));

		FileStream stream = new FileStream(path, FileMode.Open);

		objectState_Data obj= serializer.Deserialize(stream) as  objectState_Data ;

		stream.Close();

		return obj;
	}


}
