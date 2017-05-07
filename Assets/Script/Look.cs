using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Look")]
public class Look : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		controller.DisplayRoomText();
		controller.DisplayLoggedText();
	}
}
