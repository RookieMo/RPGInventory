using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Equip")]
public class Equip : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		Dictionary<string, string> equipDictionary = controller.interactableItems.EquipItem(separatedInputWords);

		if(equipDictionary != null){
			controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(equipDictionary, separatedInputWords[0], separatedInputWords[1]));
		}
	}
	
}
