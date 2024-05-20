using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase : Command
{
    public DoDamage doDamage;
    public int NumTolnc;
    public float _stepIUp;

    public override void Do(double _timer,ref int cuat)
    {
        if (_timer/(cuat*_stepIUp) > 1)
        {
            cuat++;
            if(doDamage._upgrate<NumTolnc&&cuat>0)
                doDamage._upgrate++;
        }
    }
}
