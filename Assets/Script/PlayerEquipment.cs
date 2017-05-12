using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour {

	public List<EquipSlots> equipSlot = new List<EquipSlots>();
	public InteractableObject empty;

	public InteractableObject currentItemToUnEquip;

	void Start(){
		InitialEquipEmpty();
	}

	void InitialEquipEmpty(){
		equipSlot.Add(new EquipSlots(empty, "PrimaryWeapon"));
		equipSlot.Add(new EquipSlots(empty, "SecondaryWeapon"));
		equipSlot.Add(new EquipSlots(empty, "HeadGear"));
		equipSlot.Add(new EquipSlots(empty, "Neck"));
		equipSlot.Add(new EquipSlots(empty, "Body"));
		equipSlot.Add(new EquipSlots(empty, "LeftArm"));
		equipSlot.Add(new EquipSlots(empty, "RightArm"));
		equipSlot.Add(new EquipSlots(empty, "LeftFoot"));
		equipSlot.Add(new EquipSlots(empty, "RightFoot"));
		equipSlot.Add(new EquipSlots(empty, "Index Finger"));
		equipSlot.Add(new EquipSlots(empty, "Middle Finger"));
		equipSlot.Add(new EquipSlots(empty, "Ring Finger"));
		equipSlot.Add(new EquipSlots(empty, "Cape"));
		equipSlot.Add(new EquipSlots(empty, "Bag"));
		equipSlot.Add(new EquipSlots(empty, "Belt"));
	}

	public void EquipItem(InteractableObject itemToEquip){
		if(itemToEquip.ItemType == "Weapon"){
			if(isNotEquipped("PrimaryWeapon")){
				currentItemToUnEquip = equipSlot[0].EquipObject;
				equipSlot[0].EquipObject = itemToEquip;
			} else if(isNotEquipped("SecondaryWeapon")){
				currentItemToUnEquip = equipSlot[1].EquipObject;
				equipSlot[1].EquipObject = itemToEquip;
			} else{
				currentItemToUnEquip = equipSlot[0].EquipObject;
				equipSlot[0].EquipObject = itemToEquip;
			}
		} else if(itemToEquip.ItemType == "HeadGear"){
			currentItemToUnEquip = equipSlot[2].EquipObject;
			equipSlot[2].EquipObject = itemToEquip;
		} else if(itemToEquip.ItemType == "Neck"){
			currentItemToUnEquip = equipSlot[3].EquipObject;
			equipSlot[3].EquipObject = itemToEquip;
		} else if(itemToEquip.ItemType == "Body"){
			currentItemToUnEquip = equipSlot[4].EquipObject;
			equipSlot[4].EquipObject = itemToEquip;
		} else if(itemToEquip.ItemType == "Gauntlet"){
			if(isNotEquipped("LeftArm")){
				currentItemToUnEquip = equipSlot[5].EquipObject;
				equipSlot[5].EquipObject = itemToEquip;
			} else if(isNotEquipped("RightArm")){
				currentItemToUnEquip = equipSlot[6].EquipObject;
				equipSlot[6].EquipObject = itemToEquip;
			} else{
				currentItemToUnEquip = equipSlot[5].EquipObject;
				equipSlot[5].EquipObject = itemToEquip;
			}
		} else if(itemToEquip.ItemType == "Footware"){
			if(isNotEquipped("LeftFoot")){
				currentItemToUnEquip = equipSlot[7].EquipObject;
				equipSlot[7].EquipObject = itemToEquip;
			} else if(isNotEquipped("RightFoot")){
				currentItemToUnEquip = equipSlot[8].EquipObject;
				equipSlot[8].EquipObject = itemToEquip;
			} else{
				currentItemToUnEquip = equipSlot[7].EquipObject;
				equipSlot[7].EquipObject = itemToEquip;
			}
		} else if(itemToEquip.ItemType == "Ring"){
			if(isNotEquipped("Index Finger")){
				currentItemToUnEquip = equipSlot[9].EquipObject;
				equipSlot[9].EquipObject = itemToEquip;
			} else if(isNotEquipped("Middle Finger")){
				currentItemToUnEquip = equipSlot[10].EquipObject;
				equipSlot[10].EquipObject = itemToEquip;
			} else if(isNotEquipped("Ring Finger")){
				currentItemToUnEquip = equipSlot[11].EquipObject;
				equipSlot[11].EquipObject = itemToEquip;
			} else{
				currentItemToUnEquip = equipSlot[9].EquipObject;
				equipSlot[9].EquipObject = itemToEquip;
			}
		} else if(itemToEquip.ItemType == "Cape"){
			currentItemToUnEquip = equipSlot[12].EquipObject;
			equipSlot[12].EquipObject = itemToEquip;
		} else if(itemToEquip.ItemType == "Bag"){
			currentItemToUnEquip = equipSlot[13].EquipObject;
			equipSlot[13].EquipObject = itemToEquip;
		} else if(itemToEquip.ItemType == "Belt"){
			currentItemToUnEquip = equipSlot[14].EquipObject;
			equipSlot[14].EquipObject = itemToEquip;
		}
	}
	public bool isNotEquipped(string equipSlotName){
		return equipSlot.Find(x=> x.EquipSlotName == equipSlotName).EquipObject == empty;
	}

	public InteractableObject itemToEquip(){
		return currentItemToUnEquip;
	}
}
