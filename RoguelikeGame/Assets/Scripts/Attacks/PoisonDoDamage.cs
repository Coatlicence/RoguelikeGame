using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PoisonDoDamage : DoDamageDecorator
{
    public override void Do(double _timer, ref int cuat, Vector3 pos, Quaternion quaternion)
    {
        base.Do(_timer, ref cuat, pos, quaternion);
    }
    public override async void MainAttack(Vector3 pos, Quaternion quaternion)
    {
        //quaternion.eulerAngles.Set(0, quaternion.eulerAngles.y * -1f, 0);
        Collider[] colliders = Physics.OverlapBox(new Vector3(pos.x, pos.y, pos.z), new Vector3(1, 2, 2 + weapon.GetRange()), quaternion);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable dmg))
            {
                await PoisonAsynk(dmg, UnityEngine.Random.Range(10, 20));

            }
        }
        _upgrate = 0;
    }
    private async Task PoisonAsynk(IDamagable dmg, int count)
    {
        for (int i = 0; i < count && dmg != null; i++)
        {
            await Task.Delay(500);
            if (dmg != null)
            {
                dmg.TakeDamage(Convert.ToUInt32(UnityEngine.Random.Range(2, 5)), IDamagable.SusceptibilityPair.DamageType.Poison);
            }
            else
            {
                return;
            }

        }
    }
}
