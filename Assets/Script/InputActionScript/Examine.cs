using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "RPG/InputActions/Examine")]
public class Examine : InputAction {

	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(controller.interactableItems.examineDictionary, separatedInputWords[0], separatedInputWords[1]));
		InteractableObject item = controller.interactableItems.GetInteractbleObjectFromUsableList(separatedInputWords[1]);
		for(int i = 0; i < item.stats.Count; i++){
			controller.LogString(item.stats[i].StatName + ": " + item.stats[i].BaseValue);
		}
	}
}
