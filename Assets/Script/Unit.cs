using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected string unitName;
    [SerializeField] protected int power;
    [SerializeField] protected int MaxHp;
    [SerializeField] protected int hp;
    [SerializeField] protected bool isNear;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float attackCoolTime;
    [SerializeField] protected float speed;
    [SerializeField] protected int giveCost;
    [SerializeField] protected bool isRightTeam;

    [SerializeField] protected Unit target;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected StateController stateController;


    public virtual void Setting(UnitInfo info, StateController controller, bool isRightTeam)
    {
        unitName = info.name;
        if(this.gameObject.GetComponent<SpriteRenderer>() != null)
        {
            spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = info.sprite;
        }
        power = info.power;
        MaxHp = info.MaxHp;
        hp = MaxHp;
        isNear = info.isNear;
        attackRange = info.attackRange;
        speed = info.speed;
        attackSpeed = info.attackSpeed;
        giveCost = info.giveCost;

        this.stateController = controller;
        this.isRightTeam = isRightTeam;
    }

    public virtual void Attack()
    {
        if (target != null)
        {
            /*
            if (this.isNear)
            {
                target.GetDamaged(this.power);
            }
            else
            {
<<<<<<< Updated upstream
                
=======
                GameObject obj = new GameObject();
                obj.SetActive(false);

                obj.transform.position = this.transform.position;
                obj.transform.rotation = Quaternion.identity;
                obj.AddComponent<SpriteRenderer>().sprite = bulletSprite;
                obj.GetComponent<Transform>().localScale = new Vector3(3, 3, 4);
                obj.AddComponent<Bullet>().Setting(this.target, this.power);
                obj.SetActive(true);
>>>>>>> Stashed changes
            }
            //*/
            target.GetDamaged(this.power);
        }
    }

    public virtual void Walk()
    {
        this.transform.position += new Vector3((this.isRightTeam ? -1 : 1) * this.speed, 0, 0) * Time.deltaTime;
    }
    
    public virtual void GetDamaged(int damage)
    {
        if (damage < 0)
            return;

        this.hp -= damage;
        if(hp < 0)
        {
            hp = 0;
            Destroy(this.gameObject);
        }
    }

<<<<<<< Updated upstream
=======
    public virtual void onDestory()
    {
        GameManager.Instance.killGold(this.giveCost,true);
        Destroy(this.gameObject);
    }

>>>>>>> Stashed changes
    public bool getIsRightTeam() { return isRightTeam; }
<<<<<<< Updated upstream
=======
    public float getHpRatio() { return ((float)this.hp / (float)this.MaxHp); }
>>>>>>> Stashed changes
}