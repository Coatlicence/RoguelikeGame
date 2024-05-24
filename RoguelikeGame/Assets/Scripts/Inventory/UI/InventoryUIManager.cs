using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUIManager : MonoBehaviour
{
    static InventoryUIManager singleton = null;

    public static InventoryUIManager GetInstance() {  return singleton; }

    [SerializeField] Inventory _Inventory;

    [SerializeField] TMP_Text _ItemLore;

    [SerializeField] TMP_Text _CurrentItemCount;

    [SerializeField] TMP_Text _MaxItemCount;

    [SerializeField] GameObject _InventoryGUI;

    private void Start()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton == this)
        {
            Destroy(gameObject);
            return;
        }

        UpdateMaxItemCount();
    }

    public void UpdateCurrentItemCount()
    {
        if (_CurrentItemCount) _CurrentItemCount.text = (_Inventory.GetItems().transform.childCount).ToString();
    }

    public void UpdateMaxItemCount()
    {
        _MaxItemCount.text = _Inventory.GetMaxItemCount().ToString();
    }

    public void UpdateItemLore(Item item)
    {
        _ItemLore.text = item ? item._Lore : "";
    }

    public void OpenInventory()
    {
        // Старый мой написанный код с выбрасыванием предметов и назначением не работает теперь из-за неизвестной ошибки

        _InventoryGUI.SetActive(!_InventoryGUI.activeInHierarchy);

        if (_InventoryGUI.activeInHierarchy)
            _PlayerController._Instance.SetFocus(_PlayerController.Focus.INVENTORY);
        else
            _PlayerController._Instance.SetFocus(_PlayerController.Focus.GAME);

    }
}
