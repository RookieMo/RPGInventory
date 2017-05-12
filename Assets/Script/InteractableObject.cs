using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "RPG/Interactable Object")]
public class InteractableObject : ScriptableObject {
    public string noun = "name";
    public int quantity = 1;
    [TextArea]
    public string description = "Description in room";
    public Interaction[] interactions;
    public List<InteractableObject> inventory;
    public string ItemType = "Type of item";
    public List<BaseStat> stats;
    public List<string> perks;
}
