using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStateController : StateController
{
    public const int stayState = 0;
    public const int attackState = 1;

    public TowerStateController()
    {
        AddState(); AddState();

        AddLink(stayState, attackState);
        AddLink(attackState, stayState, ("isDetectEnemy", false));
        AddLink(stayState, attackState, ("isDetectEnemy", false));
    }

    public TowerStateController(Unit unit)
    {
        AddState(); AddState();

        StateLinkUpdateAction(attackState, unit.Attack);

        AddLink(stayState, attackState);
        AddLink(attackState, stayState, ("isDetectEnemy", false));
        AddLink(stayState, attackState, ("isDetectEnemy", false));
    }
}
