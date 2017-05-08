using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	string playerName;
	string race;
	string gender;

	int carryWeight;
	int equipWeight;

	//Main Attributes
	int strength = 10;
	int perception = 10;
	int endurance = 10;
	int charisma = 10;
	int intelligence = 10;
	int agility = 10;
	int luck = 10;

	//Combat
	int attack = 10;
	int defense = 10;
	int hp = 100;
	int mana = 50;

	List<string> perks = new List<string>();
	//public List<InteractableObject> playerInventory = new List<InteractableObject>();

	//[HideInInspector] public InteractableItems interactableItems;
	GameController controller;
	void Awake(){
		controller = GetComponent<GameController>();
		//interactableItems = GetComponent<InteractableItems>();
	}
	

	public void DisplayStatus(){
		controller.LogStringWithReturn("Main Attributes: " + "\n" +
										" Strength: " + strength + "\t" +
										" Perception: " + perception + "\t\t" + 
										" Endurance: " + endurance + "\n" +
										" Charisma: " + charisma + "\t" +
										" Intelligence: " + intelligence + "\t" +
										" Agility: " + agility + "\n" +
										" Luck: " + luck + "\n" +
										"Combat: " + "\n" +
										" Attack: " + attack + "\t" +
										" Defense: " + defense + "\n" +
										" Hit Points: " + hp + "\t" +
										" Mana: " + mana);
		controller.interactableItems.DisplayInventory();
		//DisplayEquippedItems
		controller.LogStringWithReturn("List of perks: ");
		for(int i = 0; i < perks.Count; i++){
			controller.LogStringWithReturn(perks[i]);
		}
	}
}
