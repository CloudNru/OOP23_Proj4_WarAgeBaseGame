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
        CreateMonster("", Vector3.zero);
    }

    public GameObject CreateMonster(string name)
    {
        
        return CreateMonster(name, Vector3.zero);        
    }

    public GameObject CreateMonster(string name, Vector3 position)
    {
        GameObject obj = Instantiate(unitBaseObject, position, Quaternion.Euler(position));
        obj.AddComponent<Monster>().set(new StudentStateControler());
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
