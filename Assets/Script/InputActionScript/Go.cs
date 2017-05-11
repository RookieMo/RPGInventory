using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Go")]
public class Go : InputAction {

	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
	}
}
