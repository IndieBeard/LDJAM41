using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	//[SerializeField]
	//private GameObject car;

	[SerializeField]
	private Car[] cars;

	private float ypos;
	//[SerializeField]
	//private Vector3 spawnPosition;
	[SerializeField]
	private Transform min;
	[SerializeField]
	private Transform max;

	private int index;

	// Use this for initialization
	void Start () {
		//spawnPosition = new Vector3;
		StartCoroutine(spawn());
		ypos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawn(){
		while (GameManager.instance.PlayerActive == true){
			index = Random.Range(0, cars.Length);
			Instantiate (cars[index], spawnPosition(), transform.rotation);
			yield return new WaitForSeconds(1);
		} 

		
	}

	private Vector3 spawnPosition(){
		Vector3 newPos = new Vector3(Random.Range(min.position.x, max.position.x), ypos, transform.position.z);
		return newPos;
	}
}
