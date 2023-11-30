using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject unitBaseObject;

    private void Start()
    {
        unitBaseObject = (GameObject)Resources.Load("Assets/Prefab/UnitBase");
    }

    public GameObject CreateMonster(string name)
    {
        return null;        
    }

    public GameObject CreateMonster(string name, Vector3 position)
    {
        return null;
    }

    public GameObject CreateBaseCamp(bool isRight)
    {
        return null;
    }

    public GameObject CreateBaseCamp(bool isRight, Vector3 position)
    {
        return null;
    }

    public GameObject CreateTower(string name)
    {
        return null;
    }

    public GameObject CreateTower(string name, Vector3 position)
    {
        return null;
    }
}
