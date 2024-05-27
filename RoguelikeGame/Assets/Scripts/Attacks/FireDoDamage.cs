using System;
using System.Threading.Tasks;
using UnityEngine;

public class FireDoDamage : DoDamageDecorator
{
    // Start is called before the first frame update
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
                await FireAsync(dmg, UnityEngine.Random.Range(5, 10));

            }
        }
        _upgrate = 0;
    }
    private async Task FireAsync(IDamagable dmg, int count)
    {
        for(int i = 0; i < count&& dmg != null; i++)
        {
            await Task.Delay(2000);
            if (dmg != null)
            {
                dmg.TakeDamage(Convert.ToUInt32(UnityEngine.Random.Range(5, 15)), IDamagable.SusceptibilityPair.DamageType.Fire);
            }
            else
            {
                return;
            }

        }
    }
}
