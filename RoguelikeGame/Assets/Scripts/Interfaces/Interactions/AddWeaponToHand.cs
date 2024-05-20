using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class AddWeaponToHand : IInteractable
{
    Weapon weapon;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    public override void Interact(StandartController activator)
    {
        weapon.gameObject.SetActive(true);
        //weapon.transform.position = Vector3.zero;

        var at = activator.GetComponent<IAttackable>();



        at.SetFirstWeapon(weapon);
    }
}
