using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SlashDoDamage : DoDamageDecorator
{
    public override void Do(double _timer, ref int cuat, Vector3 pos, Quaternion quaternion)
    {
        base.Do(_timer, ref cuat, pos, quaternion);
    }
    public override void MainAttack(Vector3 pos, Quaternion quaternion)
    {
        //quaternion.eulerAngles.Set(0, quaternion.eulerAngles.y * -1f, 0);
        Collider[] colliders = Physics.OverlapBox(new Vector3(pos.x, pos.y, pos.z), new Vector3(1, 2, 2 + weapon.GetRange()), quaternion);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable dmg))
            {
                dmg.TakeDamage((uint)Random.Range(weapon.GetMinDamage() + _upgrate * (int)(_damageBoost * weapon.GetMinDamage()),
                    weapon.GetMaxDamage() + _upgrate * (int)(_damageBoost * weapon.GetMaxDamage())),IDamagable.SusceptibilityPair.DamageType.Physical);

            }
        }
        _upgrate = 0;
    }
}
