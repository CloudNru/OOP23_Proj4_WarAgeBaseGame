using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackStudentController : StudentStateControler
{
    public const int backState = 3;

    public BackStudentController() : base()
    {
        AddState();

        AddLink(walkState, backState, ("isDamaged", true));
        AddLink(attackState, backState, ("isDamaged", true));
        AddLink(backState, walkState, ("isDamaged", false));
    }

    public BackStudentController(Unit unit) : base(unit)
    {
        AddState();

        AddLink(walkState, backState, ("isDamaged", true));
        AddLink(attackState, backState, ("isDamaged", true));
        AddLink(backState, walkState, ("isDamaged", false));
    }
}
