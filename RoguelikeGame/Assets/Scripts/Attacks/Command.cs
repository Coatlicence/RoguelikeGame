using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Command
{
    Animation animation;
    public Weapon weapon;

    public virtual void ShowAnimation()
    {

    }
    public virtual void Do(double _timer,ref int cuat)
    {

    }

    public virtual void Do(double _timer,ref int cuat,Vector3 pos, Quaternion quaternion)
    {

    }

}
