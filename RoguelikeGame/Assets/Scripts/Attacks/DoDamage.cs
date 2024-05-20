using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : Command
{
    public int _upgrate = 0;
    public float _damageBoost;
    //float Coulddown;
    //float Knocknack;
    //int CurrentDamage;
    //int MinDamage;
    //int MaxDamage;
    public override void Do(Vector3 pos, Quaternion quaternion)
    {
        ShowAnimation();
        //quaternion.eulerAngles.Set(0, quaternion.eulerAngles.y * -1f, 0);
        Collider[] colliders = Physics.OverlapBox(new Vector3(pos.x, pos.y, pos.z), new Vector3(1, 2, 2 + weapon.GetRange()), quaternion);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable dmg))
            {
                dmg.TakeDamage(Random.Range(weapon.GetMinDamage(),weapon.GetMaxDamage()));

            }
        }
    }

    public override void Do(double _timer,ref int cuat,Vector3 pos, Quaternion quaternion)
    {
        if (cuat == 0||_timer / (cuat * weapon.GetDelayTime()) > 1)
        {
            cuat++;
            ShowAnimation();
            //quaternion.eulerAngles.Set(0, quaternion.eulerAngles.y * -1f, 0);
            Collider[] colliders = Physics.OverlapBox(new Vector3(pos.x, pos.y, pos.z), new Vector3(1, 2, 2 + weapon.GetRange()), quaternion);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<IDamagable>(out IDamagable dmg))
                {
                    dmg.TakeDamage(Random.Range(weapon.GetMinDamage() + _upgrate*(int)(_damageBoost* weapon.GetMinDamage()),
                        weapon.GetMaxDamage() + _upgrate * (int)(_damageBoost * weapon.GetMaxDamage())));
                    
                }
            }
            _upgrate = 0;
        }
    }
}
