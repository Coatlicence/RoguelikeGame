using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : Item
{
    public Emerald()
    {
        _Name   = "Изумруд";
        _Lore   = "Великолепный обработанный драгоценный камень, который может быть использован для улучшения характеристик оружия";
        _Price  = 100;
    }
    public override object Clone()
    {
        var tmp = new Emerald();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
}
