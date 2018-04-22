using UnityEngine;

[System.Serializable]
public class Dialogue{

	// a Dialogue object has three public members/attributes that
	// should be set via Unity's inspector

	// characterName is the string that will appear at the top of the dialogue UI
	public string characterName;
	// characterSprite is a Sprite that will appear in the dialogue UI
	// should be 3:4 in width:height ratio and (apparently) pixel multiples of 4
	// so, 300x400 or 480x640 or 600x800 or...
	public Sprite characterSprite;
	public Question[] questions;

	private int activeQuestionNumber;

	public int getActiveQuestionNumber(){
		return activeQuestionNumber;
	}

	public void incrementActiveQuestionNumber(){
		activeQuestionNumber += 1;
	}
}
