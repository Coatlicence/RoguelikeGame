using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Item
{
    public override object Clone()
    {

        var tmp = new Water();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
    public Water()
    {
        _Name = "Вода";
        _Lore = "Обычная вода";
        _Price = 2;
    }
}
