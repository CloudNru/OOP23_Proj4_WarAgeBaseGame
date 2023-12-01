using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public abstract class StateController
{
    private Unit unit;
    protected GenericArrayList<State> stateList = new GenericArrayList<State>();
    private Dictionary<string, bool> flag = new Dictionary<string, bool>();
    protected GenericArrayList<List<StateLink>> LinkList;
    protected ushort index = 0;

    public void setUnit(Unit unit)
    {
        this.unit = unit;
    }

    public void Update()
    {
        stateList[index].Update(unit);
        changeState();
    }

    public void changeState()
    {
        foreach (StateLink link in LinkList[index])
        {
            if (link.getKeys().Count == 0 || checkFlag(link))
            {
                stateList[index].Exit(unit);
                this.index = link.getIndex();
                stateList[index].Enter(unit);
                return;
            }
        }
    }

    protected void AddState(State state)
    {
        stateList.Add(state);
        LinkList.Add(new List<StateLink>());
    }

    protected void RemoveState(int index) 
    {
        stateList.Remove(index);
    }

    protected void InsertState(int index, State state)
    {
        stateList.insert(index, state);
    }

    protected void AddFlag(string flagName)
    {
        if(flagName == null || flagName == "")
        {
            return;
        }

        this.flag.Add(flagName, false);
    }

    protected void DeleteFlag(string flagName)
    {
        if (!flag.ContainsKey(flagName))
            return;

        flag.Remove(flagName);
    }

    public void SetFlag(string flagName, bool isTrue)
    {
        if (!flag.ContainsKey(flagName))
            return;

        flag[flagName] = isTrue;
    }

    private bool checkFlag(StateLink link)
    {
        foreach (string flagName in link.getKeys())
        {
            if (!flag.ContainsKey(flagName) || flag[flagName] != link.getValue(flagName))
            {
                return false;
            }
        }
        return true;
    }

    protected void AddLink(ushort startIndex, ushort goalIndex, params (string, bool)[] flagCondition)
    {
        LinkList[startIndex].Add(new StateLink(goalIndex, flagCondition));
    }

    protected class StateLink
    {
        private ushort goalIndex;
        private Dictionary<string, bool> flagCondition;

        public StateLink(ushort goalIndex, params (string, bool)[] flagCondition)
        {
            this.flagCondition = new Dictionary<string, bool>();
            this.goalIndex = goalIndex;

            if (flagCondition == null || flagCondition.Length <= 0)
            {
                return;
            }

            foreach ((string, bool) flag in flagCondition)
            {
                this.flagCondition.Add(flag.Item1, flag.Item2);
            }
        }

        public ushort getIndex()
        {
            return this.goalIndex;
        }

        public List<string> getKeys()
        {
            return this.flagCondition.Keys.ToList();
        }

        public bool getValue(string flagName)
        {
            return flagCondition[flagName];
        }
    }
}
