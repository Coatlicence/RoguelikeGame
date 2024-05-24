using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Contains main vars and methods for
/// world controlling
/// </summary>
public class WorldManager : MonoBehaviour
{
    public static WorldManager _Instance;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
            Destroy(this);
        else
            _Instance = this;

        DontDestroyOnLoad(this);
    }

    [Header("References")]
    [Tooltip("Always update it when moving from level to level")]
    public GameObject _CurrentLevel;

    [Tooltip("Inventory slot which contains Item inside")]
    public GameObject _ItemSlotPrefab;

    [Tooltip("Item prefab, which exists in world and can be interactable")]
    public GameObject _ItemPrefab;

    

    // Spawns item in location and Attaches it to CurrentLevel
    public GameObject SpawnItem(Type itemType, Vector3 position)
    {
        if (itemType == null)
        {
            Debug.LogError("Spawning null");
            return null;
        }

        if (itemType == typeof(Item))
        {
            Debug.LogError("Spawning abstact class Item");
            return null;
        }

        if (!itemType.IsSubclassOf(typeof(Item)))
        {
            Debug.LogError("SpawnItem cant spawn non item");
            return null;
        }

        var itemObject = Instantiate
            (
            _ItemPrefab, 
            position, 
            Quaternion.identity, 
            _CurrentLevel.transform
            );

        Item item = (Item)itemObject.AddComponent(itemType);

        if (item._Model)
            Instantiate(item._Model).transform.SetParent(item.transform, false);
        else
            Debug.LogError($"{itemType} doesnt have model");

        if (itemObject.TryGetComponent<InteractableAddItemToInventory>(out var inter))
        {
            inter._Item = item;
        }
        else
        {
            Debug.LogError("itemObject doesnt have Interactable!");
        }

        return itemObject;
    }
}
