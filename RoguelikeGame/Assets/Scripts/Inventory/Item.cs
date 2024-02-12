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
    public string _Name { get; }
    public uint _Price { get; }
    public uint _Weight { get; }
    public int _Durability { get; }
    protected int _DurabilityMax;{ get; }
    public struct Volume
    {
        public ushort _Width { get; }
        public ushort _Height { get; }
    };
    public Volume _Volume { get; }
}