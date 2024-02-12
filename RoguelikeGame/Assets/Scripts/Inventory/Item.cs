using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    //protected int _Id;
    protected string _Name;
    protected uint _Price;
    protected uint _Weight;
    protected int _Durability;
    protected int _DurabilityMax;
    struct Volume
    {
        public ushort _Length;
        public ushort _Width;
    };
    Volume _Volume;
}