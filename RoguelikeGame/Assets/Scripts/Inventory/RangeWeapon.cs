using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    //свойство определяющее текущее колличество патронов в магазине
    [SerializeField]
    protected int _NumOfAmmo;

    //метод для получения текущего колличества патронов в магазине
    public int GetNumOfAmmo() {  return _NumOfAmmo; }

    //метод для устанновки значения текущего колличества патронов в магазине
    public void SetNumOfAmmo(int value)
    {
        if(value >= 0&&value<_MaxAmmo) _NumOfAmmo=value;
        else Console.WriteLine("Incorrect NumOfAmmo");
    }

    //свойство определяющее максимальное колличество патронов в магазине
    [SerializeField]
    protected int _MaxAmmo;

    //метод для получения максимального колличества патронов в магазине
    public int GetMaxAmmo() { return _MaxAmmo; }

    //метод для установки максимального колличества патронов в магазине
    public void SetMaxAmmo(int value)
    {
        if (value > 0&&value<_NumOfAmmo) _MaxAmmo = value;
        else Console.WriteLine("Incorrect MaxAmmo");
    }

    //свойство определяющее время перезарядки оружия
    [SerializeField]
    protected float _ReloadTime;

    //метод для получения времени перезарядки
    public float GetReloadTime() {  return _ReloadTime; }

    //медод для установки времени перезарядки
    public void SetReloadTime(float value)
    {
        if (value > 0) _ReloadTime = value;
        else Console.WriteLine("Incorrect ReloadTime");
    }

    //свойство отражающее разброс оружия
    [SerializeField]
    protected int _Spread;

    //метод для получения разброса оружия
    public int GetSpread() { return _Spread; }

    //метод для установки разброса оружия
    public void SetSpread(int value)
    {
        if (value >= 0) _Spread = value;
        else Console.WriteLine("Incorrect Spread");
    }

    //свойство отражающее тип боеприпасов, используемых данным оружием
    [SerializeField]
    protected Ammo _AmmoType;

    //метод для получения типа боеприпасов оружия
    public Ammo GetAmmoType() { return _AmmoType;}

    //метод для установки типа боеприпасов оружия
    public void SetAmmoType(Ammo value) { _AmmoType = value; }

}
