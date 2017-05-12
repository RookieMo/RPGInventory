using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {
	public List<BaseStat> stats = new List<BaseStat>();

	void Start(){
		//Main Attributes
		stats.Add(new BaseStat(10, "Strength"));
		stats.Add(new BaseStat(10, "Perception"));
		stats.Add(new BaseStat(10, "Endurance"));
		stats.Add(new BaseStat(10, "Charisma"));
		stats.Add(new BaseStat(10, "Intelligence"));
		stats.Add(new BaseStat(10, "Agility"));
		stats.Add(new BaseStat(10, "Luck"));

		//Combat
		stats.Add(new BaseStat(100, "Attack"));
		stats.Add(new BaseStat(50, "Defense"));
		stats.Add(new BaseStat(1000, "Current HP"));
		stats.Add(new BaseStat(1000, "Max HP"));
		stats.Add(new BaseStat(500, "Current Mana"));
		stats.Add(new BaseStat(500, "Max Mana"));

		//Other
		stats.Add(new BaseStat(0, "Current Carry Weight"));
		stats.Add(new BaseStat(100, "Max Carry Weight"));
		stats.Add(new BaseStat(0, "Current Equip Weight"));
		stats.Add(new BaseStat(500, "Max Equip Weight"));
		stats.Add(new BaseStat(0, "Gold"));
	}

	public void AddStatBonus(List<BaseStat> statBonuses){
		foreach(BaseStat statBonus in statBonuses){
			stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}

	public void RemoveStatBonus(List<BaseStat> statBonuses){
		foreach(BaseStat statBonus in statBonuses){
			stats.Find(x=> x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}

	public void AddStatBonusWhenTake(List<BaseStat> statBonuses){
		foreach(BaseStat statBonus in statBonuses){
			if(statBonus.StatName == "Current Carry Weight"){
				stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
				break;
			}
		}
	}

	public void RemoveStatBonusWhenEquip(List<BaseStat> statBonuses){
		foreach(BaseStat statBonus in statBonuses){
			if(statBonus.StatName == "Current Carry Weight"){
				stats.Find(x=> x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
				break;
			}
		}
	}

	public void AddStatBonusWhenEquip(List<BaseStat> statBonuses){
		foreach(BaseStat statBonus in statBonuses){
			if(statBonus.StatName == "Current Carry Weight"){
				continue;
			} else {
				stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
			}
		}
	}
}
