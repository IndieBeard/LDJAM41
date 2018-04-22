using UnityEngine;

[System.Serializable]
public class Question {

	//first parameter is the minimum amount of lines the area is and the second is the max
	[TextArea(3, 20)]
	// question is what the NPC will initially ask the player
	public string question;

	// answers is an array of strings that serve as possible choices the player can select
	public string[] answers;

	// response is an array of strings that are the NPC's response to each possible choice
	// there should be as many responses as there are answers
	public string[] responses;
}
