using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Item
{
    public override object Clone()
    {

        var tmp = new HealPotion();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
    public HealPotion() 
    {
        _Name = "Исцелющее зелье";
        _Lore = "Встречается нечасто, особенно в замшелых пещерах";
        _Price = 50;
    }
}
