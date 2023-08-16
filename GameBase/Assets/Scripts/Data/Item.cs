using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string key = "";
    public ItemData itemData;
    public int Level{get; set;}= 1;
    public int AttackBonus { get; set; } = 1;
    public int MaxHpBouns { get; set; } = 1;

    public bool _isEqipped = false;
    public bool IsEquipped
    {
        get
        {
            return _isEqipped;
        }
        set
        {
            _isEqipped = value;
        }
    }

    public Item(string key)
    {
        this.key = key;
    }
}

public class ItemData
{
    public string DataId;
    public Define.ItemType itemType;
}