using UnityEngine;

[System.Serializable]
public class Question {

	// specifying the [TextArea] attribute exposes public strings as
	// editable textareas in Unity's inspector
	[TextArea]

	// question is what the NPC will initially ask the player
	public string question;

	// answers is an array of strings that serve as possible choices the player can select
	public string[] answers;

	// response is an array of strings that are the NPC's response to each possible choice
	// there should be as many responses as there are answers
	public string[] responses;
}
