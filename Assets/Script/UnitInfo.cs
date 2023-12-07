using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo
{
    public string name { get; }
    public Sprite sprite { get; }
    public int power { get; }
    public int MaxHp { get; }
    public bool isNear {  get; }
    public float attackRange {  get; }
    public float speed {  get; }
    public float attackSpeed {  get; }
    public int giveCost {  get; }
    public Sprite bulletSprite { get; }

    public UnitInfo()
    {
        this.power = 1;
        this.sprite = null;
        this.MaxHp = 20;
        this.attackRange = 2;
        this.speed = 2;
        this.attackSpeed = 1;
        this.giveCost = 10;
        this.bulletSprite = null;
    }

    //이름:sprite명:체력:공격력:공격방식:공격범위:공격속도:이동속도:비용:보상:
    public UnitInfo(string name, Sprite sprite, int maxHp, int power, bool isNear, float attackRange,float attackSpeed, float speed, int giveCost)
    {
        this.name = name;
        this.sprite = sprite;
        this.MaxHp = maxHp;
        this.power = power;
        this.isNear = isNear;
        this.attackRange = attackRange;
        this.attackSpeed = attackSpeed;
        this.speed = speed;
        this.giveCost = giveCost;
        this.bulletSprite = null;
    }

    public UnitInfo(string name, Sprite sprite, int maxHp, int power, bool isNear, float attackRange, float attackSpeed, float speed, int giveCost, Sprite bulletSprite)
    {
        this.name = name;
        this.sprite = sprite;
        this.MaxHp = maxHp;
        this.power = power;
        this.isNear = isNear;
        this.attackRange = attackRange;
        this.attackSpeed = attackSpeed;
        this.speed = speed;
        this.giveCost = giveCost;
        this.bulletSprite = bulletSprite;
    }
}