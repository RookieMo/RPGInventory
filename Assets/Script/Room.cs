﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/Room")]
public class Room : ScriptableObject {
	[TextArea]
	public string description;
	public string roomName;
	public Exit[] exits;
	public List<InteractableObject> interactableObjectsInRoom;
}
