using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    //�������� ����������� ������ �����
    [SerializeField]
    protected uint _MinDefence;

    //����� ��� ��������� ����������� ������ �����
    public uint GetMinDefence() { return _MinDefence; }

    //����� ��� ��������� ������������ ������ �����
    public void SetMinDefence(uint value)
    {
        if (value >= 0) _MinDefence = value;
        else Console.WriteLine("Incorrect MinDefence");
    }
    //�������� ������������ ������ �����
    [SerializeField]
    protected uint _MaxDefence;

    //����� ��� ��������� ������������ ������ �����
    public uint GetMaxDefence() { return _MaxDefence; }

    //����� ��� ��������� ������������ ������ �����
    public void SetMaxDefence(uint value)
    {
        if (_MaxDefence >= _MinDefence) _MaxDefence = value;
        else Console.WriteLine("Incorrect MaxDefence");
    }

    //��������� � ������ �����
    [SerializeField]
    protected Dictionary<Armor, int> _TypesOfArmor = new Dictionary<Armor, int>();
}