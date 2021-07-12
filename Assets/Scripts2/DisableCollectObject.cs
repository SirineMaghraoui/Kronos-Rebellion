using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollectObject : MonoBehaviour {

	public GameObject stungun;
	public GameObject Al_Box;
	public GameObject card;
	public GameObject lead_container;
	public GameObject container_acid;
	public GameObject accumulator;
	void Start ()
	{
		if(System.IO.File.Exists(levelOneController.kronosDataPath))
		{   
			kronos_Data kr = saveData.loadKronosData (levelOneController.kronosDataPath);

			if(kr.al_Box)
			{
				Destroy (Al_Box);
			}
			if(kr.card)
			{
				Destroy (card);
			}
			if(kr.stungun)
			{
				Destroy (stungun);
			}
			if(kr.container_lead)
			{
				Destroy (lead_container);
			}
			if(kr.accumulator)
			{
				Destroy (accumulator);
			}
			if(kr.container_acid)
			{
				Destroy (container_acid);
			}


		}

	}
	


}
