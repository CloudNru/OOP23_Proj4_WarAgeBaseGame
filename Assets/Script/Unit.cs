using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int power { get; }
    [SerializeField] protected int MaxHp { get; }
    [SerializeField] protected int hp { get; }
    [SerializeField] protected float attackRange { get; }
    [SerializeField] protected float speed { get; }
    [SerializeField] protected float attackSpeed { get;}

    [SerializeField] protected StateController stateController;
}