using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class autodrive : MonoBehaviour {

	public static bool search;
	public static int i=0;
	int j;
	bool reach=false;

	Transform target; 
	public Transform [] waypoints;

	void FixedUpdate () {
		if (playMode.mode) {
			if (search == false) {
				searchNearest ();
				search = true;
			}
			if (i < waypoints.Length) {
				reachPoint ();
			}
		} else {
			search = false;
		}

	}	


	 void searchNearest(){
		float smallest = 1000;
		for(int j=i; j < waypoints.Length;j++){
			if (dist (transform, waypoints[j]) < smallest) {
				smallest = dist(transform, waypoints[j]);
				i = j;
			}
		}
	}


	void reachPoint(){
		Quaternion rot = Quaternion.LookRotation (waypoints[i].position-transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation,rot,Time.deltaTime*2);
		transform.position=Vector3.MoveTowards(transform.position,waypoints[i].position,Time.deltaTime*15);
		if (dist(this.transform,waypoints[i]) <= 0.5) {
			move ();
			i++;
		}
	}


	float dist(Transform t1, Transform t2){
		return Vector3.Distance (t1.position, t2.position);
	}
		


	void move(){	
		int[] routes1 = new int[] {6, 14};
		int[] routes2 = new int[] {25, 40};
		int[] routes3 = new int[] {34, 51};
		if (i == 5) {
			j = Random.Range (0, routes1.Length);
			i = routes1 [j]; 
		} else if (i == 13) {
			j = Random.Range (0, routes2.Length);
			i = routes2 [j]; 
		} else if (i == 33) {
			j = Random.Range (0, routes3.Length);
			i = routes3 [j]; 
		} else if (i == 24 || i == 39) {
			i = 61;
		} else if (i == 50 || i == 60) {
			i = 73;
		} else if (i == 72) {
			i = waypoints.Length;
		} else if (i == 83) {
			i = waypoints.Length-1;
		}
	}
}
