using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {

	public List<EquipSlots> equipSlot = new List<EquipSlots>();
	public InteractableObject empty;

	void Start(){
		equipSlot.Add(new EquipSlots(empty, "HeadGear"));
		equipSlot.Add(new EquipSlots(empty, "Neck"));
		equipSlot.Add(new EquipSlots(empty, "Body"));
		equipSlot.Add(new EquipSlots(empty, "LeftArm"));
		equipSlot.Add(new EquipSlots(empty, "RightArm"));
		equipSlot.Add(new EquipSlots(empty, "PrimaryWeapon"));
		equipSlot.Add(new EquipSlots(empty, "SecondaryWeapon"));
		equipSlot.Add(new EquipSlots(empty, "LeftFoot"));
		equipSlot.Add(new EquipSlots(empty, "RightFoot"));
		equipSlot.Add(new EquipSlots(empty, "Index Finger"));
		equipSlot.Add(new EquipSlots(empty, "Middle Finger"));
		equipSlot.Add(new EquipSlots(empty, "Ring Finger"));
		equipSlot.Add(new EquipSlots(empty, "Cape"));
		equipSlot.Add(new EquipSlots(empty, "Bag"));
		equipSlot.Add(new EquipSlots(empty, "Belt"));
	}
}
