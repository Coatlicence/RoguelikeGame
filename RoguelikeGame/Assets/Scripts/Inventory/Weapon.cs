using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField]
    public BaseAttack FirstAttack;

    [SerializeField]
    public BaseAttack SecondAttack;

    //�������� ���������� ����������� ���� ������� ����� ������� ��� ������
    [SerializeField]
    protected int _MinDamage;

    //����� ��� ��������� ������������ ����� ������� ������
    public int GetMinDamage() { return _MinDamage; }

    //����� ��� ��������� ������������ ����� ������� ������
    public void SetMinDamage(int value) {
        if (value >= 0) _MinDamage = value;
        else Console.WriteLine("Incorrect MinDamage");
    }

    //�������� ���������� ������������ ���� ������
    [SerializeField]
    protected int _MaxDamage;

    //����� ��� ��������� ������������� ����� ������
    public int GetMaxDamage() { return _MaxDamage; }

    //���� ��� ��������� ������������� ����� ������
    public void SetMaxDamage(int value)
    {
        if (_MaxDamage >= _MinDamage) _MaxDamage = value;
        else Console.WriteLine("Incorrect MaxDamage");
    }

    //�������� ���������� ��������� �������� ������
    [SerializeField]
    protected int _Range;

    //����� ��� ��������� ��������� �������� ������
    public int GetRange() { return _Range; }

    //����� ��� ��������� ��������� �������� ������
    public void SetRange(int value)
    {
        if (value >= 0) _Range = value;
        else Console.WriteLine("Incorrect Range");
    }

    //�������� ���������� ����� �������� ����� ������ ������
    [SerializeField]
    protected int _DelayTime;

    //����� ��� ��������� �������� ����� ������ ������
    public int GetDelayTime() { return _DelayTime; }

    //����� ��� ��������� �������� ����� ������ ������
    public void SetDelayTime(int value)
    {
        if (value >= 0) _DelayTime = value;
        else Console.WriteLine("Incorrect Delay Time");
    }

    //����� ��� ��������� �������� ����� ������
    public int GetDamage()
    {
        return UnityEngine.Random.Range(_MinDamage, _MaxDamage)* _Durability / _DurabilityMax;
    }

    //��������, ���������� ������������ ������ ��� ����� ������
    [SerializeField]
    protected int _Knockback;

    //����� ��� ��������� �������� ������������ ��� ����� ������
    public int GetKnockback() { return _Knockback; }

    public void SetKnockback(int value)
    {
        if (value >= 0) _Knockback = value;
        else Console.WriteLine("Incorrect Knockback");
    }
}
