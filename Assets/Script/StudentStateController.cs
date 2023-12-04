using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentStateControler : StateController
{
    public const int stayState = 0;
    public const int walkState = 1;
    public const int attackState = 2;

    public StudentStateControler()
    {

        AddState(); AddState(); AddState();

        //AddFlag("isDead");
        //AddFlag("isDetectEnemy");

        AddLink(stayState, walkState);
        AddLink(walkState, attackState, ("isDetectEnemy", true));
        AddLink(attackState, walkState, ("isDetectEnemy", false));
    }

    public StudentStateControler(Unit unit)
    {
        AddState(); AddState(); AddState();

        StateLinkUpdateAction(walkState, unit.Walk);
        StateLinkUpdateAction(attackState, unit.Attack);

        //AddFlag("isDead");
        //AddFlag("isDetectEnemy");

        AddLink(stayState, walkState);
        AddLink(walkState, attackState, ("isDetectEnemy", true));
        AddLink(attackState, walkState, ("isDetectEnemy", false));
    }
}
