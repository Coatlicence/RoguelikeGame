using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo:Item
{
    public override object Clone()
    {

        var tmp = new Ammo();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
    //свойство отвечающее за урон боеприпаса
    [SerializeField]
    protected int _Damage;

    //метод для получения урона боеприпаса
    public int GetDamage() {  return _Damage; }

    //метод для установки значения боеприпаса
    public void SetDamage(int value) { 
        if(value >= 0) _Damage = value;
        else Console.WriteLine("Incorrect Ammo Damage");
    }

    //свойство отвечающее за дальность на которую летит боеприпас
    [SerializeField]
    protected int _Range;

    //метод для получение дальности 
    public int GetRange() { return _Range; }

    //метод для установки дальности полёта боеприпаса
    public void SetRange(int value)
    {
        if (value > 0) _Range = value;
        else Console.WriteLine("Incorrect Ammo Range");
    }

    //свойство отвечающее за скорость полёта боеприпаса
    [SerializeField]
    protected int _Speed;

    //метод для получения значения боеприпаса
    public int GetSpeed() { return _Speed; }

    //метод устанавливающий значение скорости боеприпаса
    public void SetSpeed(int value)
    {
        if (value > 0) _Speed = value;
        else Console.WriteLine("Incorrect Ammo Speed");
    }

    //свойство отвечающее за колличесво боеприпасов в стаке
    [SerializeField]
    protected int _CountInStack;

    //метод возвращающий колличесво боеприпасов в стаке
    public int GetCountInStack() { return _CountInStack; }

    //метод устанавливающий колличесво боеприпасов в стаке
    public void SetCountInStack(int value)
    {
        if (value > 0) _CountInStack = value;
        else Console.WriteLine("Incorrect Ammo CountInStack");
    }

}
