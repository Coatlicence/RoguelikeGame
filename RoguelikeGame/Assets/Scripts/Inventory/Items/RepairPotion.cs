using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPotion : Item
{
    public override object Clone()
    {

        var tmp = new RepairPotion();
        tmp._Name = _Name;
        tmp._Lore = _Lore;
        tmp._Price = _Price;
        return tmp;
    }
    public RepairPotion()
    {
        _Name = "����� �������";
        _Lore = "����� ������ ����� ���������������� ��������� ����������";
        _Price = 100;
    }
}
