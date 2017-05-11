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
	PlayerEquipment equipment;
	void Awake(){
		controller.GetComponent<GameController>();
		playerStats = GetComponent<PlayerStat>();
		equipment = GetComponent<PlayerEquipment>();
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
		for(int i = 0; i < equipment.equipSlot.Count; i++){
			controller.LogString(equipment.equipSlot[i].EquipSlotName + ": " + equipment.equipSlot[i].EquipObject.noun);
		}
	}

	public void DisplayPerk(){

	}

	public void playerEquipItem(InteractableObject item){
		playerStats.AddStatBonus(item.stats);
	}

	public void playerTakeItem(InteractableObject item){
		playerStats.AddStatBonus(item.stats);
	}
}
