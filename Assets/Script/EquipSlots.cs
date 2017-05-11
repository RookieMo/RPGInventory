using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlots {
	public InteractableObject EquipObject;
	public string EquipSlotName;

	public EquipSlots(InteractableObject equipObject, string equipSlotName){
		this.EquipObject = equipObject;
		this.EquipSlotName = equipSlotName;
	}
}
