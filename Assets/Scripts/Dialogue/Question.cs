using UnityEngine;

[System.Serializable]
public class Question {

	// specifying the [TextArea] attribute exposes public strings as
	// editable textareas in Unity's inspector
	[TextArea]

	// question is what the NPC will initially ask the player
	public string question;

	// an array of choice objects
	// each choice contains one playerChoice string 
	// and one corresponding npc response if that playerChoice is selected
	public Choice[] choices;
}
