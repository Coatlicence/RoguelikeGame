using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteract :IInteractable
{

    GameObject UIPotion;

    public override void Interact(StandartController activator)
    {
        UIPotion = InventoryUIManager.GetInstance()._CraftInventoryGUI;
        if (UIPotion != null) 
        {
            if(UIPotion.TryGetComponent<CraftInventory>(out var inventory))
            {
                inventory.gameObject.SetActive(true);
            }
        }
        
    }


}
