using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/InputActions/Equipment")]
public class Equipment : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		controller.player.DisplayEquipment();
	}
}
