using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class InteractableAddItemToInventory : IInteractable
{
    [SerializeField] Item item;

    public override void Interact(StandartController activator)
    {
        if (activator.TryGetComponent<Inventory>(out var inventory)) 
        {
            inventory.Add(item); 
        }
    }
}
