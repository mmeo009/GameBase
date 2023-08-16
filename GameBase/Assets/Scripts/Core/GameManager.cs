using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;
using static Define;
using Unity.VisualScripting;

public class GameManager 
{
    public GameData _gameData = new GameData();

    string _path;
        
    public void Init()
    {
        _path = Application.persistentDataPath + "/SaveData.json";

        Debug.Log("Save Path : " + _path);

        if(LoadGame())
        return;

        PlayerPrefs.SetInt("ISFIRST", 1);

    }

    public int UserLevel
    {
        get { return _gameData.UserLevel; }
        set { _gameData.UserLevel = value; }
    }

    public string UserName
    {
        get { return _gameData.UserName; }
        set { _gameData.UserName = value; }
    }

    public event Action OnResourcesChanged;
    public int Gold
    {
        get { return _gameData.Gold;}
        set { 
            _gameData.Gold = value;
            SaveGame();
            OnResourcesChanged?.Invoke();
            }
    }
    public int Dia
    {
        get { return _gameData.Dia; }
        set
        {
            _gameData.Dia = value;
            SaveGame();
            OnResourcesChanged?.Invoke();
        }
    }

    public List<Item> OwendItem
    {
        get { return _gameData.Owenditem; }
        set
        {
            _gameData.Owenditem = value;
        }
    }

    public event Action ItemsChanged;
    public Item AddEquipment(string key)
    {
        if(key.Equals("None"))
            return null;
        Item equip = new Item(key);
        OwendItem.Add(equip);
        ItemsChanged?.Invoke();

        return equip;
    }
    public Dictionary<int,int> ItemDictionary
    {
        get { return _gameData.ItemDictionary; }
        set{_gameData.ItemDictionary = value;}
    }

    public Dictionary<ItemType,Item> Items
    {
        get { return _gameData.Items; }
        set 
        { 
            _gameData.Items = value;
            ItemsChanged?.Invoke();
        }
    }

    public void EquipItem (ItemType type, Item equipment)
    {
        if(Items.ContainsKey(type))
        {
            Items[type].IsEquipped = false;
            Items.Remove(type);
        }

        Items.Add(type, equipment);
        equipment.IsEquipped = true;

        ItemsChanged?.Invoke();
        //ItemsChanged.Invoke(); 아닐때도 이벤트 호출 둘다 상관없지만
    }

    public void UnEquipItem(Item equipment) 
    {
        if (Items.ContainsKey(equipment.itemData.itemType))
        {
            Items[equipment.itemData.itemType].IsEquipped = false;
            Items.Remove(equipment.itemData.itemType);
        }

        ItemsChanged?.Invoke();
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("ISFIRST", 0);
    }

    public void AddMaterialItem(int id , int quantity)
    {
        if(ItemDictionary.ContainsKey(id))
        {
            ItemDictionary[id] += quantity;
        }
        else
        {
            ItemDictionary[id] = quantity;
        }
        SaveGame();
    }

    public void RemoveMaterialItem(int id, int quantity)
    {
        if( ItemDictionary.ContainsKey(id))
        {
            ItemDictionary[id] -= quantity;
            SaveGame();
        }
    }

    public void SaveGame()
    {
        //GameData Class 를 json으로 변환하여 저장한다
        string jsonStr = JsonConvert.SerializeObject(_gameData);
        File.WriteAllText(_path, jsonStr);
    }
    public bool LoadGame() 
    {
        if(PlayerPrefs.GetInt("ISFIRST",1) == 0)
        {
            string path = Application.persistentDataPath + "/SaveData.json";
            if(File.Exists(path)) 
                File.Delete(path);
            return false;
        }

        if(File.Exists(_path) == false)
        {
            return false;
        }
        string fileStr = File.ReadAllText(_path);
        GameData data = JsonConvert.DeserializeObject<GameData>(fileStr);

        if(data != null){_gameData = data;}
        return true;

    }
}
