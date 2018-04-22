using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	//this class is an object that we can pass into the DialogueManager whenever we want to start a new dialogue
	// Use this for initialization

	public string name;
	public int queuePos;



	//first parameter is the minimum amount of lines the area is and the second is the max
	[TextArea(3, 10)]
	public string[] sentences;
	public string[] answers1 = new string[3];
	public string[] answers2 = new string[3];
	public string[] answers3 = new string[3];
	//the sequence of correct choices
	public int[] correctChoicesSeq1 = new int[3];
	public int[] correctChoicesSeq2 = new int[3];	
	public int[] correctChoicesSeq3 = new int[3];
	//an array keeping track of correct choices


	

}
