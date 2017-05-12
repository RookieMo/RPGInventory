using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public string playerName;
	public string race;
	public string gender;

	List<string> perks = new List<string>();
	//public List<InteractableObject> playerInventory = new List<InteractableObject>();

	//[HideInInspector] public InteractableItems interactableItems;
	public GameController controller;
	PlayerStat playerStats;
	PlayerEquipment playerEquipment;
	void Awake(){
		controller.GetComponent<GameController>();
		playerStats = GetComponent<PlayerStat>();
		playerEquipment = GetComponent<PlayerEquipment>();
		//interactableItems = GetComponent<InteractableItems>();
	}

	public void DisplayStatus(){
		for(int i = 0; i < playerStats.stats.Count; i++){
			controller.LogString(playerStats.stats[i].StatName + ": " + playerStats.stats[i].GetCalculatedStatValue());
		}
	}

	public void DisplayInventory(){
		controller.interactableItems.DisplayInventory();
	}

	public void DisplayEquipment(){
		for(int i = 0; i < playerEquipment.equipSlot.Count; i++){
			controller.LogString(playerEquipment.equipSlot[i].EquipSlotName + ": " + playerEquipment.equipSlot[i].EquipObject.noun);
		}
	}

	public void DisplayPerk(){
		controller.LogStringWithReturn("List of player perks: ");
		for(int i = 0; i < perks.Count; i++){
			controller.LogString(perks[i]);
		}
	}

	public void playerEquipItem(InteractableObject item){
		playerStats.AddStatBonusWhenEquip(item.stats);
		playerEquipment.EquipItem(item);
		playerStats.RemoveStatBonus(playerEquipment.currentItemToUnEquip.stats);
		addPerk(item);
		removePerk(playerEquipment.currentItemToUnEquip);
	}

	public void playerTakeItem(InteractableObject item){
		playerStats.AddStatBonusWhenTake(item.stats);
	}

	public InteractableObject getCurrentUnEquipItem(){
		return playerEquipment.currentItemToUnEquip;
	}

	void addPerk(InteractableObject item){
		for(int i = 0; i < item.perks.Count; i++){
			if(item.perks[i] == "Absorb Fire"){
				int index = perks.FindIndex(x=> x.Equals("Resist Fire"));
				if(index != -1){
					perks[index] = "Absorb Fire";
				}
			} else if(item.perks[i] == "Absorb Cold"){
				int index = perks.FindIndex(x=> x.Equals("Resist Cold"));
				if(index != -1){
					perks[index] = "Absorb Cold";
				}
			} else{
				perks.Add(item.perks[i]);
			}
		}
	}

	void removePerk(InteractableObject item){
		for(int i = 0; i < item.perks.Count; i++){
			perks.Remove(item.perks[i]);
		}
	}
}
