using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonThrowItem : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    public void ThrowItem()
    {
        inventory.Throw(inventory._ChoosedItem);
    }
}
