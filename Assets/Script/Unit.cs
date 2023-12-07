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
    [SerializeField] protected Sprite bulletSprite;


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
        if(info.bulletSprite != null)
        {
            bulletSprite = info.bulletSprite;
        }

        this.stateController = controller;
        this.isRightTeam = isRightTeam;
    }

    public virtual void Attack()
    {
        if (target != null)
        {
            if (this.isNear)
            {
                target.GetDamaged(this.power);
            }
            else if(bulletSprite != null)
            {
                GameObject obj = new GameObject();
                obj.SetActive(false);

                obj.transform.position = this.transform.position;
                obj.transform.rotation = Quaternion.identity;
                obj.AddComponent<SpriteRenderer>().sprite = bulletSprite;
                obj.AddComponent<Bullet>().Setting(this.target, this.power);
                obj.SetActive(true);
            }
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
            onDestory();
        }
    }

    public virtual void onDestory()
    {
        GameManager.Instance.killGold(this.giveCost);
        Destroy(this.gameObject);
    }

    public bool getIsRightTeam() { return isRightTeam; }
}