using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Drop")]
public class Drop : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		Dictionary<string, string> dropDictionary = controller.interactableItems.Drop(separatedInputWords);

		if(dropDictionary != null){
			controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(dropDictionary, separatedInputWords[0], separatedInputWords[1]));
		}
	}
}
