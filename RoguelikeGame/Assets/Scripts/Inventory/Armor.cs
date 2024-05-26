using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    //свойство минимальной защиты брони
    [SerializeField]
    protected uint _MinDefence;

    //метод для получения минимальной защиты брони
    public uint GetMinDefence() { return _MinDefence; }

    //метод для установки максимальной защиты брони
    public void SetMinDefence(uint value)
    {
        if (value >= 0) _MinDefence = value;
        else Console.WriteLine("Incorrect MinDefence");
    }
    //свойство максимальной защиты брони
    [SerializeField]
    protected uint _MaxDefence;

    //метод для получения максимальной защиты брони
    public uint GetMaxDefence() { return _MaxDefence; }

    //метод для установки максимальной защиты брони
    public void SetMaxDefence(uint value)
    {
        if (_MaxDefence >= _MinDefence) _MaxDefence = value;
        else Console.WriteLine("Incorrect MaxDefence");
    }

    //Контейнер с типами брони
    [SerializeField]
    protected Dictionary<Armor, int> _TypesOfArmor = new Dictionary<Armor, int>();
}