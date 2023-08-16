using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GameData
{
    public int UserLevel = 1;
    public string UserName = "Player";

    public int Gold = 0;
    public int Dia = 0;

    public List<Item> Owenditem = new List<Item>();
    public Dictionary<int,int> ItemDictionary = new Dictionary<int,int>();
    public Dictionary<ItemType, Item> Items = new Dictionary<ItemType, Item>();

}
