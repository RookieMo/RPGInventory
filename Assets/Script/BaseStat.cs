using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStat {

	public List<StatBonus> BaseAdditives;

	public float BaseValue;
	public string StatName;
	public string StatDescription;
	float FinalValue;

	public BaseStat(float baseValue, string statName, string statDescription){
		this.BaseAdditives = new List<StatBonus>();
		this.BaseValue = baseValue;
		this.StatName = statName;
		this.StatDescription = statDescription;
	}

	public void AddStatBonus(StatBonus statBonus){
		this.BaseAdditives.Add(statBonus);
	}

	public void RemoveStatBonus(StatBonus statBonus){
		this.BaseAdditives.Remove(BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
	}

	public float GetCalculatedStatValue(){
		this.FinalValue = 0;
		this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}
}
