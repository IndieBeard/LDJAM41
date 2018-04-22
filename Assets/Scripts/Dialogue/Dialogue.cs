using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue{

	//this class is an object that we can pass into the DialogueManager whenever we want to start a new dialogue
	// Use this for initialization

	public string characterName;
	private int activeQuestionNumber;
	public Question[] questions;

	public int getActiveQuestionNumber(){
		return activeQuestionNumber;
	}

	public void incrementActiveQuestionNumber(){
		activeQuestionNumber += 1;
	}
}
