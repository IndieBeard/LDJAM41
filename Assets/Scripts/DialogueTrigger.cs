using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public GameObject TextBox;
	//public GameObject Choice1;
	//public GameObject Choice2;
	//public GameObject Choice3;
/* 
	//we want to locate our dialogue manager
	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		queuePos++;
	}
*/

	public void Start(){
		//dialogue = GetComponent<Dialogue>();
	}

		//we want to locate our dialogue manager
	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogue.sentences[dialogue.queuePos]);
		dialogue.queuePos++;
	}

	public void choices(){
		if(dialogue.queuePos == 0){
			TextBox.GetComponent<Text>().text = "Yes";			
		} 
		else if(dialogue.queuePos == 1){
			TextBox.GetComponent<Text>().text = "Good choice!";
		}
		else if(dialogue.queuePos == 2){
			TextBox.GetComponent<Text>().text = "Good choice!";
		}
	}

}
