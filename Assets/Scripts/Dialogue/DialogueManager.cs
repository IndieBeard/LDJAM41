using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	// public members should be assigned via Unity's inspector
	public Text nameText;
	public Text dialogueText;
	public Image npcImage;
	public Button[] choiceButtons = new Button[3];
	// The canvas will be assigned via Unity's inspector and should point to
	// the parent canvas object that contains all the UI elements for the dialog system.
	// We'll use this canvas object to show/hide the entire UI at once with a single call.
	public GameObject canvas;

	// currentDialogue is a private member used for convenience
	private Dialogue currentDialogue;

	void Start () {
		// hide the entire UI at start
		canvas.SetActive (false);
	}

	public void StartDialogue(Dialogue dialogue){

		Question question = dialogue.questions [dialogue.getActiveQuestionNumber ()];
		// update the text at the top to display this NPC's name
		nameText.text = dialogue.characterName;
		// update canvas's Image object's sprite attribute to point to this NPC's sprite
		npcImage.sprite = dialogue.characterSprite;

		// set the currentDialogue object to point to the dialogue object that was just passed in
		currentDialogue = dialogue;

		// first, clear all buttonTexts and hide all choiceButtons in case we don't need all of them
		for (int i = 0; i < choiceButtons.Length; i++) {
			choiceButtons[i].GetComponentInChildren<Text>().text = "";
			choiceButtons[i].gameObject.SetActive (false);
		}

		// set the text for and show the choiceButtons we do want
		for (int i = 0; i < question.choices.Length; i++) {
			choiceButtons[i].GetComponentInChildren<Text>().text = question.choices[i].playerChoice;
			choiceButtons[i].gameObject.SetActive (true);
			choiceButtons [i].interactable = true;
		}

		// show the entire UI
		canvas.SetActive (true);

		// type the question out
		StopAllCoroutines();
		StartCoroutine( TypeSentence(question.question) );
	}

	public void HandleChoiceClick(Button button){

		// disable all choice choiceButtons temporarily so the user doesn't click on something
		// while we're waiting for the UI to disappear
		for (int i = 0; i < choiceButtons.Length; i++) {
			choiceButtons [i].interactable = false;
		}

		// the choiceButtons have names "Choice1" and "Choice2" and "Choice3"
		// parse out the int so we have an index
		// there's surely a better way to do this...
		int choice_number = int.Parse(button.name.Replace("Choice", "")) - 1;

		// type out the appropriate response to the choice that the player selected
		StopAllCoroutines();
		StartCoroutine( TypeSentence( currentDialogue.questions[currentDialogue.getActiveQuestionNumber()].choices[choice_number].npcResponse ) );

		// wait a specified number of seconds before hiding the UI again
		StartCoroutine (WaitAndHideUI (3));

		// finally, increment the internal counter for that particular dialogue object
		// so that the next time it is accessed, the next question can be displayed
		currentDialogue.incrementActiveQuestionNumber();
	}

	IEnumerator TypeSentence (string sentence){
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()){
			dialogueText.text += letter;
			yield return null;
		}
	}

	IEnumerator WaitAndHideUI(int seconds){
		yield return new WaitForSeconds (seconds);
		// hide the UI
		canvas.SetActive (false);
	}
}
