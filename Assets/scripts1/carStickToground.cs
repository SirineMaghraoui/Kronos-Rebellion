using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carStickToground : MonoBehaviour {

	private RaycastHit rayHit;
	private Vector3 rayEmit;
	private int layerMask;
	private List<Vector3> car_pos=new List<Vector3>();
	private Vector3 vectForward;
	private bool car_Falign;
	// Use this for initialization
	void Start () {
		layerMask = 1 << 8;
		car_pos.Add(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		rayEmit = new Vector3 (transform.position.x,transform.position.y+5.5f,transform.position.z);
		var hit = Physics.Raycast (rayEmit, transform.up * (-1), out rayHit, 4,layerMask);
		if(Vector3.Distance(transform.position,car_pos[0])>=0.01)
		{
			car_pos.Add (transform.position);

		}
		if (hit) 
		{
			transform.position = new Vector3 (transform.position.x,rayHit.point.y,transform.position.z);
		}
		if(car_pos.Count==2)
		{
			vectForward = car_pos [1] - car_pos [0];
		
			car_pos.RemoveAt (0);
		}
		if(!car_Falign)
		{
			StartCoroutine ("car_Align");
		}
		
	}
	IEnumerator car_Align()
	{
		car_Falign = true;
		if (playMode.isMovingForward)
		{
		transform.forward = Vector3.Slerp (transform.forward, vectForward, 0.1f);
		}


		yield return new WaitForEndOfFrame();
		car_Falign = false;
	}
}
