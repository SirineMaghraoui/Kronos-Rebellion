using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicEnemies : MonoBehaviour {

	public GameObject[] enemy;
	private GameObject[] drone_num;
	private Vector3 Enemy_position;
	private int num=0; 
	private int enemy_num=10;
	void Start (){
		Invoke ("instEnem",3);
		//execute la methode instantiateEnemy aprés 5s puis refaire l'operation chaque 10s 
		InvokeRepeating ("instantiateEnemy", 6, 10);
	}
	
	void instantiateEnemy (){
		if (enemy_num > 0) {
			drone_num = GameObject.FindGameObjectsWithTag ("drone");
			if (drone_num.Length == 0) {
				num = Random.Range (0, enemy.Length);
				instEnem ();
			} else if (drone_num.Length == 1){
				if (drone_num [0].name == "drone1(Clone)"){
					num = 1;
				} else {
					num = 0;
				}
				instEnem ();
			}
		}
	}

	void instEnem(){
		Enemy_position = new Vector3 (Random.Range (100, 250), Random.Range (300, 500), Random.Range (100, 550));
		Instantiate (enemy [num], transform.position + Enemy_position, transform.rotation);
		enemy_num--;
	}
}
