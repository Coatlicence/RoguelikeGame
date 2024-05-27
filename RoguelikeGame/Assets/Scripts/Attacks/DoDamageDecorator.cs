using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageDecorator : DoDamage
{
    protected DoDamage doDamage;
    public override void Do(double _timer, ref int cuat, Vector3 pos, Quaternion quaternion)
    {
        if (cuat == 0 || _timer / (cuat * weapon.GetDelayTime()) > 1)
        {
            cuat++;

            ShowAnimation();
            MainAttack(pos,quaternion);
        }
    }
    public virtual void MainAttack(Vector3 pos, Quaternion quaternion)
    {

    }
}
