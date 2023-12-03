using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    private bool tmp = false;
    private int direction;
    private float attackCoolTime;

    public void set(UnitInfo info, StateController controller)
    {
        this.unitInfo = info;
        this.stateController = controller;
        this.stateController.StateLinkEnterAction(StudentStateControler.attackState, setColorRed);
        this.stateController.StateLinkExitAction(StudentStateControler.attackState, setColorWhite);
    }

    // Start is called before the first frame update
    void Start()
    {
        attackCoolTime = 0;
        stateController.SetFlag("isDead", false);
        direction = unitInfo.getIsRightTeam() ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(this.transform.position + new Vector3(direction * this.unitInfo.getAttackRange() / 2, 0 ,0), new Vector2(this.unitInfo.getAttackRange(), 2), 0, Vector2.zero);
        //Debug.Log(hits.Length);
        if(hits.Length > 1)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if(this.target == null && !System.Object.ReferenceEquals(hit.collider.gameObject, this.gameObject))
                {
                    Unit tmp = hit.transform.gameObject.GetComponent<Unit>();
                    if(tmp != null)
                    {
                        this.target = tmp;
                        stateController.SetFlag("isDetectEnemy", true);
                    }
                }
            }
        }
        else
        {
            stateController.SetFlag("isDetectEnemy", false);
            this.target = null;
        }
        if(attackCoolTime > 0)
        {
            attackCoolTime -= Time.deltaTime / this.unitInfo.getAttackSpeed();
        }
        this.stateController.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position + new Vector3(direction * this.unitInfo.getAttackRange() / 2, 0, 0), new Vector3(this.unitInfo.getAttackRange(), 2, 0));
    }

    public override void Attack()
    {
        if(attackCoolTime <= 0)
        {
            base.Attack();
            if(this.target != null && Random.Range(0,1000) < 500)
            {
                this.target.transform.position += Vector3.right * direction * 10;
                Debug.Log("Attack!!!");
            }
            attackCoolTime = 2;
        }
    }

    private void setColorRed()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void setColorWhite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}