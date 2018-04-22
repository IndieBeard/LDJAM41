using UnityEngine;

[System.Serializable]
public class Choice{

	// playerChoice is a string that serves as one possible choice the player can select
	public string playerChoice;

	// Specifying the [TextArea] attribute exposes public strings as
	// editable textareas in Unity's inspector.
	// If we don't specify [TextArea], the inpsector will show a TextInput instead.
	// TextAreas are nice because they support line breaks; TextInputs do not.
	[TextArea]
	// npcResponse is a string for the NPC's response to the above playChhoice
	public string npcResponse;
}
