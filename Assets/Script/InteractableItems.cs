using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {

	public List<InteractableObject> usableItemList;
	public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
	public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
	public Dictionary<string, string> dropDictionary = new Dictionary<string, string>();
	
	[HideInInspector] public List<string> nounsInRoom = new List<string>();
	public Dictionary<string, ActionResponse> openDictionary = new Dictionary<string, ActionResponse>();
	Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
	List<string> nounsInInventory = new List<string>();
	GameController controller;

	void Awake(){
		controller = GetComponent<GameController>();
	}
	public string GetObjectsNotInInventory(Room currentRoom, int i){
		InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];
		if(!nounsInInventory.Contains(interactableInRoom.noun)){
			nounsInRoom.Add(interactableInRoom.noun);
			return interactableInRoom.description;
		}

		return null;
	}

	public void AddActionResponsesToUseDictionary(){
		for(int i = 0; i < nounsInInventory.Count; i++){
			string noun = nounsInInventory[i];

			InteractableObject interactableObjectInInventory = GetInteractbleObjectFromUsableList(noun);
			if(interactableObjectInInventory == null)
				continue;

			for(int j = 0; j < interactableObjectInInventory.interactions.Length; j++){
				Interaction interaction = interactableObjectInInventory.interactions[j];
				if(interaction.actionResponse == null)
					continue;

				if(!useDictionary.ContainsKey(noun)){
					useDictionary.Add(noun, interaction.actionResponse);
				}
			}
		}
	}

	public void AddActionResponsesToOpenDictionary(){
		for(int i = 0; i < nounsInRoom.Count; i++){
			string noun = nounsInRoom[i];

			InteractableObject interactableObjectInRoom = GetInteractbleObjectFromUsableList(noun);
			if(interactableObjectInRoom == null)
				continue;

			for(int j = 0; j < interactableObjectInRoom.interactions.Length; j++){
				Interaction interaction = interactableObjectInRoom.interactions[j];
				if(interaction.actionResponse == null)
					continue;

				if(!openDictionary.ContainsKey(noun)){
					openDictionary.Add(noun, interaction.actionResponse);
				}
			}
		}
	}

	InteractableObject GetInteractbleObjectFromUsableList(string noun){
		for(int i = 0; i < usableItemList.Count; i++){
			if(usableItemList[i].noun == noun){
				return usableItemList[i];
			}
		}
		return null;
	}

	void PrepareObjectsToDrop(){
		for(int i = 0; i < nounsInInventory.Count; i++){
			string noun = nounsInInventory[i];

			InteractableObject interactableObjectInInventory = GetInteractbleObjectFromUsableList(noun);
			if(interactableObjectInInventory == null)
				continue;

			for(int j = 0; j < interactableObjectInInventory.interactions.Length; j++){
				Interaction interaction = interactableObjectInInventory.interactions[j];
				if(interaction.inputAction.keyword == "drop"){
					 dropDictionary.Add(noun, interaction.textResponse);
				 }
			}
		}
	}

	public void DisplayInventory(){
		controller.LogStringWithReturn("Inventory: ");
		for(int i = 0; i < nounsInInventory.Count; i++){
			controller.LogStringWithReturn(nounsInInventory[i]);
		}
	}

	public void ClearCollections(){
		examineDictionary.Clear();
		takeDictionary.Clear();
		nounsInRoom.Clear();
	}

	public Dictionary<string, string> Take(string[] separatedInputWords){
		string noun = separatedInputWords [1];
		if(nounsInRoom.Contains(noun)){
			nounsInInventory.Add(noun);
			AddActionResponsesToUseDictionary();
			nounsInRoom.Remove(noun);
			return takeDictionary;
		}
		else {
			controller.LogStringWithReturn("Ther is no " + noun + " here to take.");
			return null;
		}
	}

	public Dictionary<string, string> Drop(string[] separatedInputWords){
		string noun = separatedInputWords [1];
		if(nounsInInventory.Contains(noun)){
			nounsInRoom.Add(noun);
			PrepareObjectsToDrop();
			nounsInInventory.Remove(noun);
			return dropDictionary;
		}
		else {
			controller.LogStringWithReturn("Ther is no " + noun + " here to drop.");
			return null;
		}
	}

	public void UseItem(string[] separatedInputWords){
		string nounToUse = separatedInputWords[1];
		if(nounsInInventory.Contains(nounToUse)){
			if(useDictionary.ContainsKey(nounToUse)){
				bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
				if(!actionResult){
					controller.LogStringWithReturn("Hmm. Nothing happens.");
				}
			} else {
				controller.LogStringWithReturn("You can't use the " + nounToUse);
			}
		} else {
			controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory to use");
		}
	}

	public void OpenItem(string[] separatedInputWords){
		string nounToOpen = separatedInputWords[1];
		if(nounsInRoom.Contains(nounToOpen)){
			if(openDictionary.ContainsKey(nounToOpen)){
				bool actionResult = openDictionary[nounToOpen].DoActionResponse(controller);
				if(!actionResult){
					controller.LogStringWithReturn("Hmm. Nothing happens.");
				}
			} else {
				controller.LogStringWithReturn("You can't open the " + nounToOpen);
			}
		} else {
			controller.LogStringWithReturn("There is no " + nounToOpen + " in room to open");
		}
	}
}
