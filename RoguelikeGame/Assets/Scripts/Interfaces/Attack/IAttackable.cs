using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IAttackable : MonoBehaviour
{
    [SerializeField]
    Collider PlayerCollider;

    [SerializeField]
    private Transform WeaponPosition;

    [SerializeField]
    public Weapon FirstWeapon;

    [SerializeField]
    public Weapon SecondWeapon;

    public void SetFirstWeapon(Weapon weapon)
    {
        if (!weapon) return;

        var weaponModel = Instantiate(weapon.transform.GetChild(0).gameObject);

        weaponModel.transform.SetParent(WeaponPosition, false);
        weaponModel.transform.localPosition = Vector3.zero;

        FirstWeapon = weapon;
    }

    public void SetSecondWeapon(Weapon weapon)
    {
        if (!weapon) return;

        var weaponModel = Instantiate(weapon.transform.GetChild(0).gameObject);

        weaponModel.transform.SetParent(WeaponPosition, false);
        weaponModel.transform.localPosition = Vector3.zero;

        SecondWeapon = weapon;
    }

    public void UnsetFirstWeapon()
    {
        var model = WeaponPosition.transform.GetChild(0);

        Destroy(model.gameObject);

        FirstWeapon = null;
    }

    public void UnsetSecondWeapon()
    {
        var model = WeaponPosition.transform.GetChild(0);

        Destroy(model.gameObject);

        SecondWeapon = null;
    }


    public void Attack()
    {

        //if (weapon == null) return;

        //BoxCollider collider = weapon.GetComponent<BoxCollider>();

        //if (!collider)
        //    throw new System.Exception("Weapon Doesnt have BoxCollider");

        //Vector3 scale = new Vector3
        //                    (
        //                    collider.size.x * weapon.transform.localScale.x,
        //                    collider.size.y * weapon.transform.localScale.y,
        //                    collider.size.z * weapon.transform.localScale.z
        //                    );

        //Collider[] objects = Physics.OverlapBox(weapon.transform.position, scale, weapon.transform.rotation);



        //foreach (Collider obj in objects)
        //{
        //    if (obj == PlayerCollider) continue;

        //    IDamagable damagableobj = obj.GetComponent<IDamagable>();

        //    if (damagableobj != null) damagableobj.TakeDamage(weapon.Damage);
        //}
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;

        //BoxCollider collider = weapon.GetComponent<BoxCollider>();

        //if (!collider)
        //    throw new System.Exception("Weapon Doesnt have BoxCollider");

        //Vector3 scale = new Vector3
        //                    (
        //                    collider.size.x * weapon.transform.localScale.x,
        //                    collider.size.y * weapon.transform.localScale.y,
        //                    collider.size.z * weapon.transform.localScale.z
        //                    );

        //Gizmos.DrawWireCube(weapon.transform.position, scale);
    }
}
