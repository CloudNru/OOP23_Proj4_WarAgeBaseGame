using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    Action enterAction, updateAction, exitAction;

    public State() { }

    public State(Action enterAction, Action updateAction, Action exitAction)
    {
        LinkEnterAction(enterAction);
        LinkUpdateAction(updateAction);
        LinkExitAction(exitAction);
    }

    public void LinkEnterAction(Action enterAction)
    {
        if (enterAction != null)
        {
            this.enterAction = enterAction;
        }
    }

    public void LinkUpdateAction(Action updateAction)
    {
        if (updateAction != null)
        {
            this.updateAction = updateAction;
        }
    }

    public void LinkExitAction(Action exitAction)
    {
        if (exitAction != null)
        {
            this.exitAction = exitAction;
        }
    }

    public virtual void Enter() { 
        if(enterAction != null)
        {
            enterAction();
        }
    }

    public virtual void Update()
    {
        if(updateAction != null)
        { 
            updateAction();
        }
    }

    public virtual void Exit() 
    {
        if(exitAction != null)
        {
            exitAction();
        }
    }
}
