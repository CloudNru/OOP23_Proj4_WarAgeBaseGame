using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject unitBaseObject;

    private string[] data;

    private void Start()
    {
        unitBaseObject = PrefabUtility.LoadPrefabContents("Assets/Prefab/UnitBase.prefab");
        CreateMonster("", new Vector3(5, 0, 0), true);
        CreateMonster("", new Vector3(-5, 0, 0), false);
    }

    public GameObject CreateMonster(string name, bool isRightTeam)
    {
        return CreateMonster(name, Vector3.zero, isRightTeam);        
    }

    public GameObject CreateMonster(string name, Vector3 position, bool isRightTeam)
    {
        GameObject obj = Instantiate(unitBaseObject, position, Quaternion.Euler(position));
        Monster monster = obj.AddComponent<Monster>();
        monster.set(new UnitInfo(isRightTeam), new StudentStateControler(monster));
        obj.SetActive(true);
        return obj;
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
