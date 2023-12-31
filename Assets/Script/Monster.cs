﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    protected int direction;

    public override void Setting(UnitInfo info, StateController controller, bool isRightTeam)
    {
        this.gameObject.name = info.name;
        base.Setting(info, controller, isRightTeam);
        this.stateController.StateLinkEnterAction(StudentStateControler.walkState, setWalkAnim);
        this.stateController.StateLinkUpdateAction(StudentStateControler.attackState, Attack);
        this.stateController.StateLinkEnterAction(StudentStateControler.attackState, setAttackReadyAnim);
        this.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        if (!getAnimationKey().Equals("Error"))
        {
            this.spriteRenderer.sprite = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        attackCoolTime = 0;
        stateController.SetFlag("isDead", false);
        direction = this.isRightTeam ? -1 : 1;
        this.spriteRenderer.sortingOrder = 3;
    }

    // Update is called once per frame
    void Update()
    {
        detectEnemy();
        this.stateController.Update();
    }

    protected void detectEnemy()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(this.transform.position + new Vector3(direction * this.attackRange / 2, 0, 0), new Vector2(this.attackRange, 2), 0, Vector2.zero);
        //Debug.Log(hits.Length);

        bool isRight = false;
        if (hits.Length > 1)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (!ReferenceEquals(hit.collider.gameObject, this.gameObject))
                {
                    Unit tmp = hit.transform.gameObject.GetComponent<Unit>();
                    if (tmp != null && tmp.getIsRightTeam() != this.isRightTeam)
                    {
                        if (this.target == null)
                        {
                            isRight = true;
                            this.target = tmp;
                            stateController.SetFlag("isDetectEnemy", true);
                        }
                        else if (ReferenceEquals(this.target, tmp))
                        {
                            isRight = true;
                        }
                    }
                }
            }
        }

        if (!isRight)
        {
            stateController.SetFlag("isDetectEnemy", false);
            this.target = null;
        }
        if (attackCoolTime > 0)
        {
            attackCoolTime -= Time.deltaTime / this.attackSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position + new Vector3(direction * this.attackRange / 2, 0, 0), new Vector3(this.attackRange, 2, 0));
    }

    public override void Attack()
    {
        if(this.target == null)
        {
            return;
        }

        if (attackCoolTime <= 0 )
        {
            this.animator.Play(getAnimationKey() + "Attack");
            base.Attack();
            Debug.Log("Attack!!!");
            attackCoolTime = 1;
        }
        else if(attackCoolTime < 0.5f)
        {
            this.animator.Play(getAnimationKey() + "Ready");
        }
    }

    private void setWalkAnim()
    {
        this.animator.Play(getAnimationKey() + "Walk");
    }

    private void setAttackReadyAnim()
    {
        if(this.attackCoolTime > 0.5f)
        {
            this.attackCoolTime = 0.5f;
            this.animator.Play(getAnimationKey() + "Ready");
        }
    }

    private string getAnimationKey()
    {
        switch (this.unitName)
        {
            case "FirstStudentMelee":
                return "Melee1";
            case "SecondStudentMelee":
                return "Melee2";
            case "ThirdStudentMelee":
                return "Melee3";
            case "FourthStudentMelee":
                return "Melee4";
            case "FirstStudentRange":
                return "Range1";
            case "SecondStudentRange":
                return "Range2";
            case "ThirdStudentRange":
                return "Range3";
            case "FourthStudentRange":
                return "Range4";
            default:
                return "Error";
        }
    }
}