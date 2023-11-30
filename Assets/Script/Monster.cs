using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    bool detectEnemy; 
    bool detectFriedly;
    bool dead;

    public void set(StateController controller)
    {
        stateController = controller;
    }

    // Start is called before the first frame update
    void Start()
    {
        detectEnemy = false;
        detectFriedly = false;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        stateController.changeState(detectEnemy, detectFriedly, dead);
        stateController.Updeate(this);

        detectEnemy = false;
        detectFriedly = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            detectEnemy = true;
        }
        else if(collision.tag == "Friendly")
        {
            detectFriedly = true;
        }
    }
}
