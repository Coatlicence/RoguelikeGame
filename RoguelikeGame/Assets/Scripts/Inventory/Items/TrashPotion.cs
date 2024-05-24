using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPotion : Item
{
    public override object Clone()
    {

        var tmp = new TrashPotion();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
    public TrashPotion()
    {
        _Name = "Испорченное зелье";
        _Lore = "Кто то испортил ценные ингридиенты на это";
        _Price = 1;
    }
}
