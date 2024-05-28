using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class to object with user interact
/// </summary>
public class CraftingInteract :IInteractable
{
    /// <summary>
    /// interface to open
    /// </summary>
    GameObject UIPotion;

    /// <summary>
    /// mhetod to interact user with this gameObject to open inventory interface
    /// </summary>
    /// <param name="activator"></param>
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
