using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Perk")]
public class Perk : InputAction {

	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		controller.player.DisplayPerk();
	}
}
