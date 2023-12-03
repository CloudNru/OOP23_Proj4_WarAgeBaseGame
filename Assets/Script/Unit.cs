using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected UnitInfo unitInfo;

    [SerializeField] protected Unit target;
    [SerializeField] protected StateController stateController;

    public virtual void Attack()
    {
        if(target != null)
        {
            target.unitInfo.getDamage(this.unitInfo.getPower());
        }
    }

    public virtual void Walk()
    {
        this.transform.position += new Vector3((unitInfo.getIsRightTeam() ? -1 : 1) * unitInfo.getSpeed(), 0, 0) * Time.deltaTime;
    }
}