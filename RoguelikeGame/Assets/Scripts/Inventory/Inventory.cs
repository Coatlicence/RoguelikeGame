using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected uint _MaxItemCount = 10;

    [Header("Container of Slot objects")]
    [SerializeField] protected GameObject _Items;

    // Choosed Item presents the item in inventory on UI info tab
    private Item _choosedItem;

    public Item _ChoosedItem
    {
        get
        {
            return _choosedItem;
        }
        set
         {
            if (!value)
            {
                _choosedItem = null;
                InventoryUIManager.GetInstance().UpdateItemLore(null);
                return;
            }

            if (!HasItem(value))
            {
                _choosedItem = null;
                InventoryUIManager.GetInstance().UpdateItemLore(null);
                return;
            }

            if (_choosedItem && _choosedItem.transform.parent.TryGetComponent<Image>(out var oldimage))
            {
                oldimage.color = new(.3f, .3f, .3f);
            }

            _choosedItem = value;

            if (_choosedItem.transform.parent.TryGetComponent<Image>(out var image))
            {
                image.color = new(.7f, .5f, .3f);
            }

            InventoryUIManager.GetInstance().UpdateItemLore(_choosedItem);
        }
    }

    public uint GetMaxItemCount() { return _MaxItemCount; }

    public GameObject GetItems() { return _Items; }

    // Tries to get component Item on world gameObject
    public bool Add(GameObject item)
    {
        if (!item) { return false; }

        if (item.TryGetComponent<Item>(out var itemComponent))
        {
            return Add(itemComponent);
        }

        return false;
    }

    public bool Add(Item item)
    {
        if (item == null)
            return false;

        if (_Items.transform.childCount >= _MaxItemCount)
            return false;

        // Creates slot
        var slot = Instantiate(WorldManager._Instance._ItemSlotPrefab).GetComponent<ItemCell>();

        // Standart value for non choosed item
        slot.GetComponentInParent<Image>().color = new Color(0.3f, 0.3f, 0.3f);

        // Sets slot to _Items for futher containig
        slot.transform.SetParent(_Items.transform, false);

        slot._Item = item;

        // Most important action. Without parenting it to slot, it will not work
        item.transform.SetParent(slot.transform, false);

        item.gameObject.SetActive(false);

        slot.UpdateNameAndIcon();

        var eventClick = slot.GetComponent<Button>().onClick;

        eventClick.AddListener(() => { _ChoosedItem = item; });

        InventoryUIManager.GetInstance().UpdateCurrentItemCount();

        return true;
    }

    private void Start()
    {
        Add(typeof(Emerald));
    }

    public bool Add(Type itemType)
    {
        // Create item prefab        
        var itemObject = WorldManager._Instance.SpawnItem(itemType, new Vector3(0, 0, 0));

        if (!itemObject)
        {
            Debug.LogError($"Trying to add {itemType} type, but SpawnItem cant Instantiate this");
            return false;
        }

        // assign it with other function
        return Add(itemObject.GetComponent<Item>());
    }

    public void Throw(Item item)
    {
        if (item) Throw(item.GetType());
    }

    /// <summary>
    /// Finds first type match and throws it from player inventory
    /// !!!!!!! All Throw methods must attach items to WorldManager._Instance._CurrentLevel!!!!!
    /// WorldManager components exists on Managers prefab. Just put it on Level
    /// </summary>
    /// <param name="itemType"></param>
    public void Throw(Type itemType)
    {
        var item = HasItem(itemType);
        if (!item) 
            return;

        var slot = item.transform.parent.gameObject;

        if (item == _ChoosedItem)
            _ChoosedItem = null;

        item.transform.SetParent(WorldManager._Instance._CurrentLevel.transform, false);

        slot.transform.SetParent(null, false);

        Destroy(slot);

        item.gameObject.SetActive(true);

        item.transform.position = transform.position;

        InventoryUIManager.GetInstance().UpdateCurrentItemCount();

        Iterator it = new(this);
        _ChoosedItem = it._Item;
    }

    public Item HasItem(Type item)
    {
        for (Iterator it = new(this); it != null; it++)
        {
            if (it._Item.GetType() == item)
                return it._Item;
        }

        return null;
    }

    public bool HasItem(Item item)
    {
        if (!item) return false;

        for (Iterator it = new(this); it != null; it++)
        {
            if (it._Item == item)
                return true;
        }

        return false;
    }
    public List<Item> GetItemsList()
    {
        List<Item> list = new List<Item>();
        for (Iterator it = new(this); it != null; it++)
        {
            if (it._Item!=null)
            {
                list.Add(it._Item);
            }
            
        }
        return list;
    }

}
public class Iterator
{
    public Iterator(Inventory inventory)
    {
        Begin(inventory);
    }

    private int _Index;

    private Inventory _Inventory;

    public Item _Item { get; private set; }

    private void GetItemInInventoryByIndex()
    {
        var items = _Inventory.GetItems().transform;

        if (items.childCount > 0)
        {
            _Item = items.GetChild(_Index).GetChild(2).GetComponent<Item>();
        }
    }

    public static Iterator operator ++(Iterator it)
    {
        if (!it._Inventory) 
        { 
            Debug.LogError("No inventory assigned to iterator"); 
            return it; 
        }

        it._Index++;

        if (it._Index >= it._Inventory.GetItems().transform.childCount) 
            return null;

        it.GetItemInInventoryByIndex();
        return it;
    }

    public static Iterator operator --(Iterator it)
    {
        if (!it._Inventory)
        {
            Debug.LogError("No inventory assigned to iterator");
            return it;
        }

        it._Index--;

        if (it._Index < 0) it._Index = 0;

        it.GetItemInInventoryByIndex();
        return it;
    }

    public void SetInventory(Inventory inventory)
    {
        _Inventory = inventory;
    }

    public void Begin()
    {
        _Index = 0;
        GetItemInInventoryByIndex();
    }

    public void Begin(Inventory inventory)
    {
        SetInventory(inventory);
        Begin();
    }

    public void End()
    {
        _Index = _Inventory.GetItems().transform.childCount - 1;
        GetItemInInventoryByIndex();
    }

    public void End(Inventory inventory)
    {
        SetInventory(inventory);
        End();
    }

    /// <summary>
    /// Tris to find item in choosed inventory, and sets _Index to actual
    /// In fail _Item will be null
    /// </summary>
    /// <param name="item"></param>
    public void SetItem(Type item)
    {
        for (Iterator it = new(_Inventory); it._Item != null; it++)
        {
            if (item == it._Item.GetType())
            {
                _Index = it._Index;
                return;
            }
        }

        _Item = null;
    }

    public void SetItem(Item item)
    {
        for (Iterator it = new(_Inventory); it._Item != null; it++)
        {
            if (item == it._Item)
            {
                _Index = it._Index;
                return;
            }
        }

        _Item = null;
    }

}
