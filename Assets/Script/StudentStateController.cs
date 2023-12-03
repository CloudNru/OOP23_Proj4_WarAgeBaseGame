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
        LinkList = new GenericArrayList<List<StateLink>>();

        AddState(new StayState());
        AddState(new WalkState());
        AddState(new AttackState());

        AddFlag("isDead");
        AddFlag("isDetectEnemy");

        AddLink(stayState, walkState);
        AddLink(walkState, attackState, ("isDetectEnemy", true));
        AddLink(attackState, walkState, ("isDetectEnemy", false));
    }

    public StudentStateControler(Unit unit)
    {
        AddState(new StayState());
        AddState(new WalkState());
        AddState(new AttackState());

        StateLinkUpdateAction(walkState, unit.Walk);
        StateLinkUpdateAction(attackState, unit.Attack);

        AddFlag("isDead");
        AddFlag("isDetectEnemy");

        AddLink(stayState, walkState);
        AddLink(walkState, attackState, ("isDetectEnemy", true));
        AddLink(attackState, walkState, ("isDetectEnemy", false));
    }

    

    protected class StayState : State { }

    protected class WalkState : State { }

    protected class AttackState : State { }
}
