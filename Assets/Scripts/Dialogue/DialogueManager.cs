using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Image npcImage;

	public Button[] buttons = new Button[3];
	public Dialogue currentDialogue;

	// the canvas will be assigned via Unity's inspector and should point to
	// the parent canvas object that contains all the UI elements for the dialog system
	// we'll use this canvas object to show/hide the entire UI at once with a single call
	public GameObject canvas;

	void Start () {
		// hide the entire UI at start
		canvas.SetActive (false);
	}


	// Update is called once per frame
	void Update () {

	}


	public void StartDialogue(Dialogue dialogue){

		Question question = dialogue.questions [dialogue.getActiveQuestionNumber ()];
		// update the text at the top to display this NPC's name
		nameText.text = dialogue.characterName;
		// update canvas's Image object's sprite attribute to point to this NPC's sprite
		npcImage.sprite = dialogue.characterSprite;

		// set the currentDialogue object to point to the dialogue object that was just passed in
		currentDialogue = dialogue;

		// first, clear all buttonTexts and hide all buttons in case we don't need all of them
		for (int i = 0; i < buttons.Length; i++) {
			buttons[i].GetComponentInChildren<Text>().text = "";
			buttons[i].gameObject.SetActive (false);
		}

		// set the text for and show the buttons we do want
		for (int i = 0; i < question.answers.Length; i++) {
			buttons[i].GetComponentInChildren<Text>().text = question.answers[i];
			buttons[i].gameObject.SetActive (true);
			buttons [i].interactable = true;
		}

		// show the entire UI
		canvas.SetActive (true);

		// type the question out
		StopAllCoroutines();
		StartCoroutine( TypeSentence(question.question) );
	}

	public void HandleChoiceClick(Button button){

		// disable all choice buttons temporarily so the user doesn't click on something
		// while we're waiting for the UI to disappear
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].interactable = false;
		}

		// the buttons have names "Choice1" and "Choice2" and "Choice3"
		// parse out the int so we have an index
		// there's surely a better way to do this...
		int choice_number = int.Parse(button.name.Replace("Choice", "")) - 1;

		// type out the appropriate response to the choice that the player selected
		StopAllCoroutines();
		StartCoroutine( TypeSentence( currentDialogue.questions[currentDialogue.getActiveQuestionNumber()].responses[choice_number] ) );

		// wait a specified number of seconds before hiding the UI again
		StartCoroutine (WaitAndHideUI (2));


		// finally, increment the internal counter for that particular dialogue object
		// so that the next time it is accessed, the next question can be selected
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
