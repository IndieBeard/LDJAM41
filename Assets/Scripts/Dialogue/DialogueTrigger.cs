using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	//we want to locate our dialogue manager
	public void TriggerDialogue(){
		// perform a simple bounds check to ensure that this dialogue object has more questions
		// that haven't yet been answered before attempting to call StartDialogue()
		if (dialogue.getActiveQuestionNumber () < dialogue.questions.Length) {
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
		}
	}
}
