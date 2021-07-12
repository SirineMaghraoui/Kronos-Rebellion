using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
public class saveData  {


	public delegate void SerializeAction();
	public static event SerializeAction OnBeforeSave;	
	// armored car
	public static armoredCar armCar=new armoredCar();
	//drones 



	//save && load armored car 
	public static void Save(string path, armoredCarData arm)
	{
		
		OnBeforeSave ();//event pour dire au voiture que tu doit appeler la methode storeData

		saveobjectData(path, arm);


	}
	public static void AddcarData(armoredCarData data)
	{
		armCar.carData=data;

	}

	public static armoredCarData Loadobject(string path)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(armoredCarData));

		FileStream stream = new FileStream(path, FileMode.Open);

		armoredCarData arm = serializer.Deserialize(stream) as armoredCarData;

		stream.Close();

		return arm;
	}
	public  static void saveobjectData(string path, armoredCarData arm)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(armoredCarData));

		FileStream stream = new FileStream(path, FileMode.Create);

		serializer.Serialize(stream,arm);

		stream.Close();

	}



}
