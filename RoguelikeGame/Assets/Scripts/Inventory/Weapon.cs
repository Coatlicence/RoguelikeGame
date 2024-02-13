using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    //свойство отражающее минимальный урон который может нанести это оружее
    [SerializeField]
    protected int _MinDamage;

    //метод для получения минимального урона данного оружия
    public int GetMinDamage() { return _MinDamage; }

    //метод для установки минимального урона данного оружия
    public void SetMinDamage(int value) {
        if (value >= 0) _MinDamage = value;
        else Console.WriteLine("Incorrect MinDamage");
    }

    //свойство отражающее максимальный урон оружия
    [SerializeField]
    protected int _MaxDamage;

    //метод для получения максимального урона оружия
    public int GetMaxDamage() { return _MaxDamage; }

    //мето для установки максимального урона оружия
    public void SetMaxDamage(int value)
    {
        if (_MaxDamage >= _MinDamage) _MaxDamage = value;
        else Console.WriteLine("Incorrect MaxDamage");
    }

    //свойство отражающее дальность действия оружия
    [SerializeField]
    protected int _Range;

    //метод для получения дальности действия оружия
    public int GetRange() { return _Range; }

    //метод для установки дальности действия оружия
    public void SetRange(int value)
    {
        if (value >= 0) _Range = value;
        else Console.WriteLine("Incorrect Range");
    }

    //свойство отражающее время задержки перед атакой оружия
    [SerializeField]
    protected int _DelayTime;

    //метод для получения задержки перед атакой оружия
    public int GetDelayTime() { return _DelayTime; }

    //метод для установки задержки перед атакой оружия
    public void SetDelayTime(int value)
    {
        if (value >= 0) _DelayTime = value;
        else Console.WriteLine("Incorrect Delay Time");
    }

    //метод для получения текущего урона оружия
    public int GetDamage()
    {
        return UnityEngine.Random.Range(_MinDamage, _MaxDamage)* _Durability / _DurabilityMax;
    }

}
