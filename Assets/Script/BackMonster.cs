using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMonster : Monster
{
    private int count = 0;

    public override void Setting(UnitInfo info, StateController controller, bool isRightTeam)
    {
        base.Setting(info, new BackStudentController(this), isRightTeam);

        this.stateController.StateLinkEnterAction(BackStudentController.backState, back);
    }

    public void back()
    {
        this.transform.position -= Vector3.right * direction * 5;
        stateController.SetFlag("isDamaged", false);
    }

    public override void GetDamaged(int damage)
    {
        base.GetDamaged(damage);
        if(damage > 0)
        {
            count++;
            if(count >= 3)
            {
                count = 0;
                stateController.SetFlag("isDamaged", true);
            }
        }
    }
}
