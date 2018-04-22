using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Text[] buttonTexts = new Text[3];
	//public Animator animator;
	public Dialogue currentDate;

	//this variable will keep track of all our options in our dialogue
	private Queue<string> sentences;
	private bool awaitingInput;
	private int choiceSelected = 0;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
	
	// Update is called once per frame
	void Update () {

	}
/* 
	public void StartDialogue(Dialogue dialogue){

		nameText.text = dialogue.name;

		//animator.SetBool("IsOpen", true);

		//Clear is a Queue function that will clear any sentences that were there on a previous conversation
		sentences.Clear();

		foreach (string sentence in dialogue.sentences){
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}
*/

	public void StartDialogue(Dialogue dialogue, string sentence){
		nameText.text = dialogue.name;
		currentDate = dialogue;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));

		if(dialogue.queuePos == 0){
			for(int i = 0; i <= dialogue.answers1.Length; i++){
				buttonTexts[i].text = dialogue.answers1[i];
			}
		}	
		if(dialogue.queuePos == 1){
			for(int i = 0; i <= dialogue.answers1.Length; i++){
				buttonTexts[i].text = dialogue.answers2[i];
			}
		}
		if(dialogue.queuePos == 2){
			for(int i = 0; i <= dialogue.answers1.Length; i++){
				buttonTexts[i].text = dialogue.answers3[i];
			}
		}	
	}

	public void choice1(){
		//currentDate.choiceMade(1);
	}

	public void choice2(){
		//currentDate.choiceMade(2);
	}

	public void choice3(){
		//currentDate.choiceMade(3);
	}

	public void DisplayNextSentence(){
		if (sentences.Count == 0){//if we are at the end of our sentences, end the dialogue
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));

	}

	IEnumerator TypeSentence (string sentence){
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()){
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue(){
		Debug.Log("End of conversation");
		//animator.SetBool("IsOpen", false);
	}

}
