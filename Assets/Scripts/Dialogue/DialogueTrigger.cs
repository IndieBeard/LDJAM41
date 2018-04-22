using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	//we want to locate our dialogue manager
	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogue.questions[dialogue.getActiveQuestionNumber()]);
	}
}
