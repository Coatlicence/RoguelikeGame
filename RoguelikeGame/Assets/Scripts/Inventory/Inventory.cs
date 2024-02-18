using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    [SerializeField] protected uint _Size = 20;
     
    [SerializeField] protected Dictionary<Item, uint> _Items;

    private void Awake()
    {
        _Items = new Dictionary<Item, uint>();
    }

    public bool Take(Item item, uint count)
    {
        if (item == null)
            return false;    
            
        if (_Items.Count == _Size)
            return false;

        
        if (_Items.ContainsKey(item))
            _Items[item] += count;
        else
            _Items.Add(item, count);

        return true;
    }

    // удаляет предмет в заданном количестве, возвращает истину, 
    public bool Remove(Item item, uint count)
    {
        if (item == null)
            return false;

        if (_Items.Count == 0)
            return false;

        if (!_Items.ContainsKey(item))
            return false;

        if (_Items[item] < count)
            return false;


        _Items[item] -= count;

        if (_Items[item] == 0)
            _Items.Remove(item);

        

        return true;
    }

    // Возвращает количество выбранного предмета
    public uint Has(Item item)
    {
        if (item == null)
            return 0;

        if (_Items.Count == 0)
            return 0;

        if (_Items.ContainsKey(item))
            return _Items[item];

        return 0;
    }

    // возвращает истину, если в инвентаре есть или больше количества выбранного элемента
    public bool Has(Item item, uint count)
    {
        if (item == null)
            return false;

        if (_Items.Count == 0)
            return false;


        if (_Items.ContainsKey(item) && _Items[item] >= count)
            return true;
        else
            return false;

    }
}
