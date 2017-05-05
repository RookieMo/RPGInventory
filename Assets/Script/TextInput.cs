using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {

	public InputField inputField;
	GameController controller;

	void Awake(){
		controller = GetComponent<GameController>();
		inputField.onEndEdit.AddListener(AcceptStringInput);
	}
	void AcceptStringInput(string userInput){
		userInput = userInput.ToLower();
		controller.LogStringWithReturn(userInput);

		char[] delimitterCharacters = { ' ' };
		string[] separatedInputWords = userInput.Split(delimitterCharacters);

		for(int i = 0; i < controller.inputActions.Length; i++){
			InputAction inputActions = controller.inputActions[i];
			if(inputActions.keyword == separatedInputWords[0]){
				inputActions.RespondToInput(controller, separatedInputWords);
			}
		}
		InputComplete();
	}

	void InputComplete(){
		controller.DisplayLoggedText();
		inputField.ActivateInputField();
		inputField.text = null;
	}
}
