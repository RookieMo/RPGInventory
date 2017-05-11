using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public List<BaseStat> Stats { get; set; }
	public string ObjectSlug { get; set; }

	public Item(List<BaseStat> _Stats, string _ObectSlug){
		this.Stats = _Stats;
		this.ObjectSlug = _ObectSlug;
	}
}
