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
    //�������� ���������� �� ���� ����������
    [SerializeField]
    protected int _Damage;

    //����� ��� ��������� ����� ����������
    public int GetDamage() {  return _Damage; }

    //����� ��� ��������� �������� ����������
    public void SetDamage(int value) { 
        if(value >= 0) _Damage = value;
        else Console.WriteLine("Incorrect Ammo Damage");
    }

    //�������� ���������� �� ��������� �� ������� ����� ���������
    [SerializeField]
    protected int _Range;

    //����� ��� ��������� ��������� 
    public int GetRange() { return _Range; }

    //����� ��� ��������� ��������� ����� ����������
    public void SetRange(int value)
    {
        if (value > 0) _Range = value;
        else Console.WriteLine("Incorrect Ammo Range");
    }

    //�������� ���������� �� �������� ����� ����������
    [SerializeField]
    protected int _Speed;

    //����� ��� ��������� �������� ����������
    public int GetSpeed() { return _Speed; }

    //����� ��������������� �������� �������� ����������
    public void SetSpeed(int value)
    {
        if (value > 0) _Speed = value;
        else Console.WriteLine("Incorrect Ammo Speed");
    }

    //�������� ���������� �� ���������� ����������� � �����
    [SerializeField]
    protected int _CountInStack;

    //����� ������������ ���������� ����������� � �����
    public int GetCountInStack() { return _CountInStack; }

    //����� ��������������� ���������� ����������� � �����
    public void SetCountInStack(int value)
    {
        if (value > 0) _CountInStack = value;
        else Console.WriteLine("Incorrect Ammo CountInStack");
    }

}
