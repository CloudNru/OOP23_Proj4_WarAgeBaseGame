using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public abstract class StateController
{
    protected State[] stateList;
    protected ushort index;
    protected bool isDetectEnemy;
    protected bool isDetectFriedly;
    protected bool isDead;

    public abstract void changeState(bool detectEnemy, bool detectFriedly, bool dead);

    public void Updeate(Unit obj)
    {
        stateList[index].Update(obj);
    }
}
