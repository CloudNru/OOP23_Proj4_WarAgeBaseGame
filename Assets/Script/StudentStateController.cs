using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentStateControler : StateController
{
    private const ushort Stay = 0;
    private const ushort Walk = 1;
    private const ushort Attack = 2;
    private const ushort Dead = 3;

    public StudentStateControler()
    {
        stateList = new State[4];
        stateList[Stay] = new StayState();
        stateList[Walk] = new WalkState();
        stateList[Attack] = new AttackState();
        stateList[Dead] = new DeadState();
    }

    public override void changeState(bool detectEnemy, bool detectFriedly, bool dead)
    {
        if (isDead)
        {
            index = Dead;
            return;
        }

        switch (index)
        {
            case Stay:
                if (!isDetectEnemy)
                {
                    index = Walk;
                }
                else
                {
                    index = Attack;
                }
                break;

            case Walk:
                if (isDetectEnemy)
                {
                    index = Attack;
                }
                break;

            case Attack:
                if (!isDetectEnemy)
                {
                    index = Walk;
                }
                break;
        }
    }
    protected class StayState : State
    {
    }

    protected class WalkState : State
    {
        public override void Update(Unit obj)
        {
            base.Update(obj);
            obj.transform.position += new Vector3(0, 1, 1);
        }
    }

    protected class AttackState : State
    {
    }

    protected class DeadState : State
    {
    }
}
