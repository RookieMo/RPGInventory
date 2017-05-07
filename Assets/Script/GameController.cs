using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text displayText;
	public InputAction[] inputActions;
	[HideInInspector] public RoomNavigation roomNavigation;
	[HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();
	[HideInInspector] public InteractableItems interactableItems;
	[HideInInspector] public Player player;
	List<string> actionLog = new List<string>();
	// Use this for initialization
	void Awake () {
		interactableItems = GetComponent<InteractableItems>();
		roomNavigation = GetComponent<RoomNavigation>();
		player = GetComponent<Player>();
	}

	void Start(){
		DisplayRoomText();
		DisplayLoggedText();
	}
	public void DisplayLoggedText(){
		string logAsText = string.Join("\n", actionLog.ToArray());

		displayText.text = logAsText;
	}

	public void DisplayRoomText(){
		ClearCollectionsForNewRooms();
		UnpackRoom();
		string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());
		string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

		LogStringWithReturn(combinedText);
	}
	
	void UnpackRoom(){
		roomNavigation.UnpackExitsInRoom();
		PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
	}

	void PrepareObjectsToTakeOrExamine(Room currentRoom){
		for(int i = 0; i < currentRoom.interactableObjectsInRoom.Count; i++){
			 string descriptionNotInInventory = interactableItems.GetObjectsNotInInventory(currentRoom, i);
			 if(descriptionNotInInventory != null){
				 interactionDescriptionsInRoom.Add(descriptionNotInInventory);
			 }
			 InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];
			 
			 for(int j = 0; j < interactableInRoom.interactions.Length; j++){
				 Interaction interaction = interactableInRoom.interactions[j];
				 if(interaction.inputAction.keyword == "examine"){
					 interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
				 }

				 if(interaction.inputAction.keyword == "take"){
					 interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
				 }
			 }
		}
		interactableItems.AddActionResponsesToOpenDictionary();
	}

	public void PrepareNewObjectsToTakeOrExamine(InteractableObject newInteractObject){
		for(int j = 0; j < newInteractObject.interactions.Length; j++){
			Interaction interaction = newInteractObject.interactions[j];
			if(interaction.inputAction.keyword == "examine"){
				interactableItems.examineDictionary.Add(newInteractObject.noun, interaction.textResponse);
			}

			if(interaction.inputAction.keyword == "take"){
				interactableItems.takeDictionary.Add(newInteractObject.noun, interaction.textResponse);
			}
		}
	}

	public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun){
		if(verbDictionary.ContainsKey(noun)){
			return verbDictionary[noun];
		}
		return "You can't " + verb + " " + noun;
	}

	void ClearCollectionsForNewRooms(){
		interactableItems.ClearCollections();
		interactionDescriptionsInRoom.Clear();
		roomNavigation.ClearExits();
	}
	public void LogStringWithReturn(string stringToAdd){
		actionLog.Add(stringToAdd + "\n");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
