using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Status")]
public class Status : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		//controller.interactableItems.DisplayInventory();
	}
}
