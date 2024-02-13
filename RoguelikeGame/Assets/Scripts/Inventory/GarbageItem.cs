using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GarbageItem : Item
{
    GarbageItem(String name, uint weight)
    {
        _Name = name;
        _Price = 0;
        _Weight = weight;
    }
}
