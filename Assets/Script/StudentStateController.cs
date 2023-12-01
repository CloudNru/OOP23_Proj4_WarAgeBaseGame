using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentStateControler : StateController
{
    protected const int stayState = 0;
    protected const int walkState = 1;
    protected const int attackState = 2;

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

    protected class StayState : State
    {
        public StayState() { }
    }

    protected class WalkState : State
    {
        public WalkState() { }

        public override void Update(Unit obj)
        {
            base.Update(obj);
            obj.transform.position += new Vector3(Random.Range(-2.0f, 2.0f), 0, 0);
        }
    }

    protected class AttackState : State
    {
        public override void Enter(Unit obj)
        {
            base.Enter(obj);
            obj.GetComponent<SpriteRenderer>().color = Color.red;
        }

        public override void Exit(Unit obj)
        {
            base.Exit(obj);
            obj.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
