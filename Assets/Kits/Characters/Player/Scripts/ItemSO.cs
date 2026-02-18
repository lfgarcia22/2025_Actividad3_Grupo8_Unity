using System;
using UnityEngine;

public enum ItemType 
{
    Weapon,
    Armor,
    Consumable
}

[CreateAssetMenu(fileName = "Scriptable Objects/Item SO")]
public class ItemSO : ScriptableObject
{
    public ItemType type;
    public float damage;
    public string nameItem;
    public int levelToTake;
    public Sprite icon;
    
}
