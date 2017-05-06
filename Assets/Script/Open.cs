using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Open")]
public class Open : InputAction {
	public override void RespondToInput (GameController controller, string[] separatedInputWords){
		//controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(controller.interactableItems.examineDictionary, separatedInputWords[0], separatedInputWords[1]));
	}

}
