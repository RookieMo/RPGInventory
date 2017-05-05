using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {
	public Room currentRoom;

	GameController controller;

	void Awake(){
		controller = GetComponent<GameController>();
	}

	public void UnpackExitsInRoom(){
		for(int i=0; i<currentRoom.exits.Length; i++){
			controller.interationDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
		}
	}
}
