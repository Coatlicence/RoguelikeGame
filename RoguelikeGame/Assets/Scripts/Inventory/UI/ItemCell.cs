using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [Header("Item")]
    public Item _Item;

    [Header("Cell info")]
    [SerializeField] private TMP_Text _ItemName;

    [SerializeField] private Image _ItemIcon;
    public Image GetImage() { return _ItemIcon; }
    public void UpdateNameAndIcon()
    {
        _ItemName.text = _Item._Name;
        _ItemIcon.sprite = _Item._Icon;
    }

}
