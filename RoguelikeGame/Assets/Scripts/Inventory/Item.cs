using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    // Имя предмета
    public string _Name;

    // Описание
    [Multiline]
    public string _Lore;

    // Стандартная ценность предмета (может варьироваться от купца к купцу)
    // Цена указана как для продажи, так и для покупки
    [SerializeField] protected uint _Price;

    [SerializeField] protected int _Durability;
    [SerializeField] protected int _DurabilityMax;

    public Sprite Icon;

}