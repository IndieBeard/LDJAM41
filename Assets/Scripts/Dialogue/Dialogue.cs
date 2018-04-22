using UnityEngine;

[System.Serializable]
public class Dialogue{

	public string characterName;
	public Sprite characterSprite;

	private int activeQuestionNumber;
	public Question[] questions;

	public int getActiveQuestionNumber(){
		return activeQuestionNumber;
	}

	public void incrementActiveQuestionNumber(){
		activeQuestionNumber += 1;
	}
}
