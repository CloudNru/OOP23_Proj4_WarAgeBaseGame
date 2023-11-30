using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void Enter(Unit obj) { }
    public virtual void Update(Unit obj) { }
    public virtual void Exit(Unit obj) { }
}
