using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/// <summary>
/// inventory of craft table
/// </summary>
public class CraftInventory : Inventory
{
    /// <summary>
    /// Inventory of player
    /// </summary>
    [SerializeField]
    Inventory inventory;
    /// <summary>
    /// list with recipe to current place
    /// </summary>
    static List<Recipe> recipes;
    /// <summary>
    /// list with ingidients added by player
    /// </summary>
    static List<Type>  currentIndigrients;
    /// <summary>
    /// perform on start game
    /// </summary>
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

    /// <summary>
    /// perform on activate gameObject
    /// </summary>
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
    /// <summary>
    /// perform on disable gameObject
    /// </summary>
    private void OnDisable()
    {
        UpdateMainData();
        //var inv = _PlayerController._Instance.GetComponent<Inventory>();
        //inv = inventory;
        //_PlayerController._Instance.SetFocus(_PlayerController.Focus.GAME);
    }
    /// <summary>
    /// update current items
    /// </summary>
    private void UpdateDate()
    {
        while (_Items.transform.childCount > 0)
        {
            DestroyImmediate(_Items.transform.GetChild(0).gameObject);
        }

    }
    /// <summary>
    /// update items in player inventory
    /// </summary>
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
    /// <summary>
    /// add choosen item in player inventory to current indigrients
    /// </summary>
    public void AddIgridient()
    {
        if (_ChoosedItem != null)
        {
            Type tmp = _ChoosedItem.GetType();
            currentIndigrients.Add(tmp);
            Delete(tmp);
        }
    }
    /// <summary>
    /// add water to current indigrients
    /// </summary>
    public void AddWater()
    {
        currentIndigrients.Add(typeof(Water));
    }
    /// <summary>
    /// add shufle to current indigrients
    /// </summary>
    public void AddShufle()
    {
        currentIndigrients.Add(typeof(Shoflle));
    }
    /// <summary>
    /// create potion by current indigriens and list of recipe
    /// </summary>
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
