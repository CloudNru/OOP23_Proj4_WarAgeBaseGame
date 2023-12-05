using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, this.attackRange, Vector2.zero);
        //Debug.Log(hits.Length);
        if (hits.Length > 1)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (this.target == null && !System.Object.ReferenceEquals(hit.collider.gameObject, this.gameObject))
                {
                    Unit tmp = hit.transform.gameObject.GetComponent<Unit>();
                    if (tmp != null)
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
        if (attackCoolTime > 0)
        {
            attackCoolTime -= Time.deltaTime / this.attackSpeed;
        }
        this.stateController.Update();
    }

    public override void Walk() { }
}
