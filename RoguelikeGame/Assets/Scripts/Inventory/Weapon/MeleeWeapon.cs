using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public MeleeWeapon()
    {

    }

    public MeleeWeapon(string type, int minDamage, int maxDamage, int range, int delayTime, int knockback) : base(type, minDamage, maxDamage, range, delayTime, knockback)
    {
    }
}
