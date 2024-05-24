using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.Examples.TMP_ExampleScript_01;
using static UnityEditor.Progress;

public class CraftInventory : Inventory
{
    // Start is called before the first frame update
    [SerializeField]
    Inventory inventory;
    static List<Recipe> recipes;
    static List<Type>  currentIndigrients;
    private void Awake()
    {
        recipes = new List<Recipe>();
        var tmp = new Recipe();
        Item tm = new Emerald();
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Shoflle));
        tmp.ingridients.Add(typeof(FruitGlowBash));
        tmp.Rezult = typeof(HealPotion) ;
        recipes.Add(tmp);

        tmp = new Recipe();
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Water));
        tmp.Rezult = typeof(HealPotion);
        recipes.Add(tmp);
        currentIndigrients = new List<Type>();
    }
    void OnEnable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.CRAFT);
        _PlayerController._Instance.CraftStation = gameObject;
        for (Iterator it = new(inventory); it != null; it++)
        {
            if (it._Item != null)
            {
                Add(it._Item);
                _ChoosedItem = it._Item;
            }
        }

    }
    private void OnDisable()
    {
        //_PlayerController._Instance.SetFocus(_PlayerController.Focus.GAME);
    }

    public void Delete(Type itemType)
    {
        var item = HasItem(itemType);
        if (!item)
            return;

        var slot = item.transform.parent.gameObject;

        if (item == _ChoosedItem)
            _ChoosedItem = null;

        item.transform.SetParent(null, false);

        slot.transform.SetParent(null, false);

        Destroy(slot);

        Destroy(item.gameObject);



        InventoryUIManager.GetInstance().UpdateCurrentItemCount();

        Iterator it = new(this);
        _ChoosedItem = it._Item;
    }
    public void Delete(Item item)
    {
        if (item) Delete(item.GetType());
    }
    public void AddIgridient()
    {
        var tmp = _ChoosedItem.GetType();
        currentIndigrients.Add(tmp);
        Delete(_ChoosedItem);
    }
    public void AddWater()
    {
        currentIndigrients.Add(typeof(Water));
    }
    public void AddShufle()
    {
        currentIndigrients.Add(typeof(Shoflle));
    }
    public void CreatePotion()
    {
        if (currentIndigrients.Count == 0) return;
        foreach (Recipe recipe in recipes)
        {
            int i;
            for (i = 0; i < recipe.ingridients.Count; i++)
            {
                if (!(currentIndigrients[i].Equals(recipe.ingridients[i])))
                    break;

            }
            if(i== recipe.ingridients.Count)
            {
                HealPotion tm = (HealPotion)Activator.CreateInstance(recipe.Rezult);
                Add(tm);
                currentIndigrients = new List<Type>();
                return;
            }
        }
        Add(new TrashPotion());
        currentIndigrients = new List<Type>();
        return;
    }
    private void UpdatePicture()
    {


    }
    //public bool AddNew(Item item)
    //{
    //    if (item == null)
    //        return false;

    //    if (_Items.transform.childCount >= _MaxItemCount)
    //        return false;

    //    var slottmp = Instantiate(_ItemSlotPrefab);
    //    var slot = slottmp.GetComponent<ItemCell>();
    //    var tmp =slot.GetComponent<InventoryItem>();
    //    //tmp.SetHeldItem(slottmp);

    //    slot.GetComponentInParent<Image>().color = new Color(0.3f, 0.3f, 0.3f);

    //    slot.transform.SetParent(_Items.transform, false);

    //    slot._Item = item;

    //    item.transform.SetParent(slot.transform, false);

    //    item.gameObject.SetActive(false);

    //    slot.UpdateNameAndIcon();

    //    var eventClick = slot.GetComponent<Button>().onClick;

    //    eventClick.AddListener(() => { _ChoosedItem = item; });

    //    InventoryUIManager.GetInstance().UpdateCurrentItemCount();

    //    return true;
    //}
}
