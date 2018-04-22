﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour{

	//name of the character
	//private string name;

	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3 (0, -1, 0) * speed *Time.deltaTime);
	}
}