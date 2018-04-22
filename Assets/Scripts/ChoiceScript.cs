using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour {

	public GameObject TextBox;
	public GameObject Choice1;
	public GameObject Choice2;
	public GameObject Choice3;
	public int ChoiceMade;

	public void ChoiceOption1(){
		TextBox.GetComponent<Text>().text = "Good choice!";
		ChoiceMade = 1;
	}

	public void ChoiceOption2(){
		TextBox.GetComponent<Text>().text = "Meh...";
		ChoiceMade = 2;
	}

	public void ChoiceOption3(){
		TextBox.GetComponent<Text>().text = "Wow fuck you";
		ChoiceMade = 3;
	}


	void Update () {
		if (ChoiceMade >= 1){
		}
	}
}
