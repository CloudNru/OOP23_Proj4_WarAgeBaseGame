using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo
{
    [SerializeField] private int power;
    [SerializeField] private int MaxHp;
    [SerializeField] private int hp;
    [SerializeField] private float attackRange;
    [SerializeField] private float speed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int giveCost;
    [SerializeField] private bool isRightTeam;

    public UnitInfo()
    {
        this.power = 1;
        this.MaxHp = 20;
        this.hp = this.MaxHp;
        this.attackRange = 2;
        this.speed = 2;
        this.attackSpeed = 1;
        this.giveCost = 10;
        this.isRightTeam = false;
    }

    public UnitInfo(bool isRightTeam) : this()
    {
        this.isRightTeam = isRightTeam;
    }

    public UnitInfo(int power, int maxHp, float attackRange, float speed, float attackSpeed, int giveCost, bool isRightTeam)
    {
        this.power = power;
        this.MaxHp = maxHp;
        this.hp = maxHp;
        this.attackRange = attackRange;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
        this.giveCost = giveCost;
        this.isRightTeam = isRightTeam;
    }

    public int getPower() { return power; }
    public float getAttackRange() { return attackRange; }
    public float getSpeed() { return speed; }
    public float getAttackSpeed() { return attackSpeed; }
    public int getGiveCost() {  return giveCost; }

    public void setIsRightTeam(bool isRightTeam) {  this.isRightTeam = isRightTeam; }
    public bool getIsRightTeam() {  return isRightTeam; }

    public void getDamage(int damage)
    {
        if (damage < 0)
            return;

        this.hp -= damage;
        this.hp = Mathf.Clamp(this.hp, 0, MaxHp);
    }
}