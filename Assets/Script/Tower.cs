using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = unitName;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.spriteRenderer.sortingOrder = 2;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, this.attackRange, Vector2.zero);
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
        this.stateController.Update();
    }

    public override void Attack()
    {
        if (attackCoolTime <= 0 && this.target != null)
        {
            base.Attack();
            Debug.Log("Attack!!!");
            attackCoolTime = 3;
        }
    }

    public override void Walk() { }
}
