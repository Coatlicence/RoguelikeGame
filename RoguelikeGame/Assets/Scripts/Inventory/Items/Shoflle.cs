using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoflle : Item
{
    public override object Clone()
    {

        var tmp = new Shoflle();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
    //Только для зельеварения
    public Shoflle() 
    {
        _Name = "Shufle";
    }
}
