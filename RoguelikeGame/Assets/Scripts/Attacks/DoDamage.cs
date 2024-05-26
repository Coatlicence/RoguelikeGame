using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoDamage : Command
{
    protected int _upgrate = 0;
    public int GetUpgrade()
    {
        return _upgrate;
    }
    public void SetUpgrage(int upgrage)
    {
        if (upgrage < 0) throw new System.Exception("argument < 0");
        _upgrate=upgrage;
    }
    protected float _damageBoost;
    public float GetdamageBoost()
    {
        return _damageBoost;
    }
    public void SetdamageBoost(float damageBoost)
    {
        if (damageBoost < 0) throw new System.Exception("argument < 0");
        _damageBoost = damageBoost;
    }
    //float Coulddown;
    //float Knocknack;
    //int CurrentDamage;
    //int MinDamage;
    //int MaxDamage;
    public override void ShowAnimation()
    {
        _PlayerController._Instance.animator.SetTrigger("Attack");
    }
    public override void Do(Vector3 pos, Quaternion quaternion)
    {
        ShowAnimation();
        //quaternion.eulerAngles.Set(0, quaternion.eulerAngles.y * -1f, 0);
        Collider[] colliders = Physics.OverlapBox(new Vector3(pos.x, pos.y, pos.z), new Vector3(1, 2, 2 + weapon.GetRange()), quaternion);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable dmg))
            {
                uint damage = (uint)Random.Range(weapon.GetMinDamage(), weapon.GetMaxDamage());

                dmg.TakeDamage(damage);

            }
        }
    }

    public override void Do(double _timer,ref int cuat,Vector3 pos, Quaternion quaternion)
    {

    }
}
