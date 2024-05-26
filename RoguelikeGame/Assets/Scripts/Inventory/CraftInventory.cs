using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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
        tmp.Rezult = typeof(HealPotion);
        recipes.Add(tmp);

        tmp = new Recipe();
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Water));
        tmp.Rezult = typeof(HealPotion);
        recipes.Add(tmp);

        tmp = new Recipe();
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Emerald));
        tmp.ingridients.Add(typeof(Shoflle));
        tmp.ingridients.Add(typeof(FruitGlowBash));
        tmp.ingridients.Add(typeof(Water));
        tmp.Rezult = typeof(RepairPotion);
        recipes.Add(tmp);

        tmp = new Recipe();
        tmp.ingridients.Add(typeof(Water));
        tmp.ingridients.Add(typeof(FruitGlowBash));
        tmp.ingridients.Add(typeof(Shoflle));
        tmp.ingridients.Add(typeof(FruitGlowBash));
        tmp.ingridients.Add(typeof(Shoflle));
        tmp.Rezult = typeof(HealPotion);
        recipes.Add(tmp);
        currentIndigrients = new List<Type>();

    }
    void OnEnable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.CRAFT);
        _PlayerController._Instance.CraftStation = gameObject;
        UpdateDate();
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
        UpdateMainData();
        //var inv = _PlayerController._Instance.GetComponent<Inventory>();
        //inv = inventory;
        //_PlayerController._Instance.SetFocus(_PlayerController.Focus.GAME);
    }

    private void UpdateDate()
    {
        while (_Items.transform.childCount > 0)
        {
            DestroyImmediate(_Items.transform.GetChild(0).gameObject);
        }

    }
    private void UpdateMainData()
    {
        while (_PlayerController._Instance.GetComponent<Inventory>().GetItems().transform.childCount > 0)
        {
            DestroyImmediate(_PlayerController._Instance.GetComponent<Inventory>().GetItems().transform.GetChild(0).gameObject);
        }
        for (Iterator it = new(this); it != null; it++)
        {
            if (it._Item != null)
            {
                _PlayerController._Instance.GetComponent<Inventory>().Add(it._Item);
                _PlayerController._Instance.GetComponent<Inventory>()._ChoosedItem = it._Item;
            }
        }
    }
    public void AddIgridient()
    {
        if (_ChoosedItem != null)
        {
            Type tmp = _ChoosedItem.GetType();
            currentIndigrients.Add(tmp);
            Delete(tmp);
        }
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
            if (recipe.ingridients.Count != currentIndigrients.Count)
            {
                continue;
            }
            int i;
            for (i = 0; i < recipe.ingridients.Count; i++)
            {
                if (!(currentIndigrients[i].Equals(recipe.ingridients[i])))
                    break;

            }
            if(i== recipe.ingridients.Count)
            {
                Add(recipe.Rezult);
                inventory.Add(recipe.Rezult);
                currentIndigrients = new List<Type>();
                return;
            }
        }
        for (int i = 0; i < currentIndigrients.Count; i++)
        {
            if (!(currentIndigrients[i]==typeof(Water)|| currentIndigrients[i] == typeof(Shoflle)))
            {
                Add(typeof(TrashPotion));
                currentIndigrients = new List<Type>();
                inventory.Add(typeof(TrashPotion));
                return;
            }   

        }
        if (currentIndigrients.Contains(typeof(Water)))
        {
            Add(typeof(Water));
            currentIndigrients = new List<Type>();
            inventory.Add(typeof(Water));
            return;
        }
        return;
    }

}
