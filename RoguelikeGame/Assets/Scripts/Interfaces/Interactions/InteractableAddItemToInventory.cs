using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAddItemToInventory : IInteractable
{
    public Item _Item;

    public override void Interact(StandartController activator)
    {
        if (!_Item) return;

        if (activator.TryGetComponent<Inventory>(out var inventory)) 
        {
            inventory.Add(_Item); 
        }
    }
}
