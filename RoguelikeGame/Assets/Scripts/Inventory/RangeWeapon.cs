using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    //�������� ������������ ������� ����������� �������� � ��������
    [SerializeField]
    protected int _NumOfAmmo;

    //����� ��� ��������� �������� ����������� �������� � ��������
    public int GetNumOfAmmo() {  return _NumOfAmmo; }

    //����� ��� ���������� �������� �������� ����������� �������� � ��������
    public void SetNumOfAmmo(int value)
    {
        if(value >= 0&&value<_MaxAmmo) _NumOfAmmo=value;
        else Console.WriteLine("Incorrect NumOfAmmo");
    }

    //�������� ������������ ������������ ����������� �������� � ��������
    [SerializeField]
    protected int _MaxAmmo;

    //����� ��� ��������� ������������� ����������� �������� � ��������
    public int GetMaxAmmo() { return _MaxAmmo; }

    //����� ��� ��������� ������������� ����������� �������� � ��������
    public void SetMaxAmmo(int value)
    {
        if (value > 0&&value<_NumOfAmmo) _MaxAmmo = value;
        else Console.WriteLine("Incorrect MaxAmmo");
    }

    //�������� ������������ ����� ����������� ������
    [SerializeField]
    protected float _ReloadTime;

    //����� ��� ��������� ������� �����������
    public float GetReloadTime() {  return _ReloadTime; }

    //����� ��� ��������� ������� �����������
    public void SetReloadTime(float value)
    {
        if (value > 0) _ReloadTime = value;
        else Console.WriteLine("Incorrect ReloadTime");
    }

    //�������� ���������� ������� ������
    [SerializeField]
    protected int _Spread;

    //����� ��� ��������� �������� ������
    public int GetSpread() { return _Spread; }

    //����� ��� ��������� �������� ������
    public void SetSpread(int value)
    {
        if (value >= 0) _Spread = value;
        else Console.WriteLine("Incorrect Spread");
    }

    //�������� ���������� ��� �����������, ������������ ������ �������
    [SerializeField]
    protected Ammo _AmmoType;

    //����� ��� ��������� ���� ����������� ������
    public Ammo GetAmmoType() { return _AmmoType;}

    //����� ��� ��������� ���� ����������� ������
    public void SetAmmoType(Ammo value) { _AmmoType = value; }

}
