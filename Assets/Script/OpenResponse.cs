using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/ActionResponses/OpenResponse")]
public class OpenResponse : ActionResponse {
	public InteractableObject openObject;
	public override bool DoActionResponse(GameController controller){
		if(controller.interactableItems.nounsInRoom.Contains(requiredString)){
			//controller.roomNavigation.currentRoom.interactableObjectsInRoom.Remove(closeObject);
			//controller.roomNavigation.currentRoom.interactableObjectsInRoom.Add(openObject);
			controller.LogStringWithReturn("You open the closet. There has a ...");
			for(int i = 0; i < openObject.inventory.Count; i++){
				controller.roomNavigation.currentRoom.interactableObjectsInRoom.Add(openObject.inventory[i]);
				controller.PrepareNewObjectToTakeOrExamine(openObject.inventory[i]);
				controller.interactableItems.nounsInRoom.Add(openObject.inventory[i].noun);
				controller.LogString(openObject.inventory[i].description);
			}
			openObject.inventory.Clear();
			controller.interactableItems.AddActionResponsesToOpenDictionary();
			return true;
		}
		return false;
	}
}
