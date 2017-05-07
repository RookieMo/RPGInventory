using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Open")]
public class Open : InputAction {
	public override void RespondToInput (GameController controller, string[] separatedInputWords){
		controller.interactableItems.OpenItem(separatedInputWords);
	}

}
