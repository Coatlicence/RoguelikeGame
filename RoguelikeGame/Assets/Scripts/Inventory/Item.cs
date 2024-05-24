using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    // Имя предмета
    public string _Name;
    public string GetName()
    {
        return _Name;
    }
    public void SetName(string value)
    {
        if (value != null) { _Name = value; }
        else Console.WriteLine("Incorrect Name");
    }

    // Описание
    [Multiline]
    public string _Lore;
    public string GetLore()
    {
        return _Lore;
    }
    public void SetLore(string value)
    {
        if (value != null) { _Lore = value; }
        else Console.WriteLine("Incorrect Lore");
    }

    // Стандартная ценность предмета (может варьироваться от купца к купцу)
    // Цена указана как для продажи, так и для покупки
    [SerializeField] protected uint _Price;
    public uint GetPrice()
    {
        return _Price;
    }
    public void SetPrice(uint value)
    {
        if (value >=0) { _Price = value; }
        else Console.WriteLine("Incorrect Price");
    }

    [SerializeField] protected int _Durability;
    public int GetDurability()
    {
        return _Durability;
    }
    public void SetDurability(int value)
    {
        if (value >= 0&&value<_DurabilityMax) { _Durability = value; }
        else Console.WriteLine("Incorrect Durability");
    }

    [SerializeField] protected int _DurabilityMax;
    public int GetDurabilityMax()
    {
        return _Durability;
    }
    public void SetDurabilityMax(int value)
    {
        if (value >= _Durability) { _DurabilityMax = value; }
        else Console.WriteLine("Incorrect Durability");
    }

    public Sprite _Icon;

    public GameObject _Model;

    private void Awake()
    {
        LoadAssets();
    }

    private void LoadAssets()
    {
        _Icon = Resources.Load($"Icons/{GetType().Name}") as Sprite;
        _Model = Resources.Load($"Models/{GetType().Name}") as GameObject;

        if (!_Icon)     Debug.LogError($"Icon for {GetType().Name} is null");
        if (!_Model)    Debug.LogError($"Model for {GetType().Name} is null");
    }

}