using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    private int direction;

    public override void Setting(UnitInfo info, StateController controller, bool isRightTeam)
    {
        base.Setting(info, controller, isRightTeam);
        this.stateController.StateLinkEnterAction(StudentStateControler.walkState, setWalkAnim);
        this.stateController.StateLinkUpdateAction(StudentStateControler.attackState, Attack);
        this.stateController.StateLinkEnterAction(StudentStateControler.attackState, setAttackReadyAnim);
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
        RaycastHit2D[] hits = Physics2D.BoxCastAll(this.transform.position + new Vector3(direction * this.attackRange / 2, 0 ,0), new Vector2(this.attackRange, 2), 0, Vector2.zero);
        //Debug.Log(hits.Length);

        bool isRight = false;
        if (hits.Length > 1)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if(!ReferenceEquals(hit.collider.gameObject, this.gameObject))
                {
                    Unit tmp = hit.transform.gameObject.GetComponent<Unit>();
                    if(tmp != null && tmp.getIsRightTeam() != this.isRightTeam)
                    {
                        if(this.target == null)
                        {
                            isRight = true;
                            this.target = tmp;
                            stateController.SetFlag("isDetectEnemy", true);
                        }
                        else if(ReferenceEquals(this.target, tmp))
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
        if(attackCoolTime > 0)
        {
            attackCoolTime -= Time.deltaTime / this.attackSpeed;
        }
        this.stateController.Update();
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
            base.Attack();
            Debug.Log("Attack!!!");
            this.animator.Play(getAnimationKey() + "Attack");
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
        string result = "";
        if (this.isNear)
        {
            result = "Melee";
        }
        else
        {
            result = "Range";
        }

        switch (this.unitName)
        {
            case "FirstStudent":
                result += "1";
                break;
            case "SecondStudent":
                result += "2";
                break;
            case "ThirdStudent":
                result += "3";
                break;
            case "FourthStudent":
                result += "4";
                break;
            default:
                result += "Error";
                break;
        }

        return result;
    }
}