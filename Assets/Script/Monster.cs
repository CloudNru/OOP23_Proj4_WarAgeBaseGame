using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    private bool tmp = false;

    public void set(StateController controller)
    {
        this.stateController = controller;
        this.stateController.setUnit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        stateController.SetFlag("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,1000) < 1)
        {
            tmp = !tmp;
            this.stateController.SetFlag("isDetectEnemy", tmp);
        }

        this.stateController.Update();
    }
}
