using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(IDamagable))]
public class LootTable : MonoBehaviour
{
    [SerializeField]
    List<LootPair> LootList = new();

    [Tooltip("Automatically assign method OnDie to _Damagable.OnDie")]
    IDamagable _Damagable;

    private void Awake()
    {
        _Damagable = GetComponent<IDamagable>();

        if (!_Damagable)
        {
            Debug.LogError("LootTable cant find _Damagable component on gameObject");
        }

        _Damagable.onDie += OnDie;
    }

    /// <summary>
    /// Spawn items from LootList with given chances
    /// </summary>
    private void OnDie()
    {
        foreach (var pair in LootList) 
            if (UnityEngine.Random.Range(0f, 1f) < pair._Chance)
            {
                Vector3 pos = transform.position;

                pos.x += UnityEngine.Random.Range(-2f, 2f);
                pos.z += UnityEngine.Random.Range(-2f, 2f);

                WorldManager._Instance.SpawnItem(pair._Item.GetType(), pos);
            }
    }
}

[Serializable]
struct LootPair
{
    [Tooltip("After call damagable.OnDie LootTable will create ItemPrefab with copy of that component")]
    public Item _Item;

    [Tooltip("After destroy LootTable will create ItemPrefab with given chance. values(0; 1)")]
    [Range(0, 1)]
    public float _Chance;
}