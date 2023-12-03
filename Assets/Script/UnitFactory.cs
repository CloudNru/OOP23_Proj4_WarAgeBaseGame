using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject unitBaseObject;

    private Dictionary<string, UnitInfo> data;

    private void Start()
    {
        data = new Dictionary<string, UnitInfo>();
        unitBaseObject = PrefabUtility.LoadPrefabContents("Assets/Prefab/UnitBase.prefab");
        string[] datas = File.ReadAllLines("Assets/DataFile/DataText.txt");
        foreach (string t in datas)
        {
            string[] tmp = t.Split(':'); 
            if(tmp.Length == 10)
            {
                //이름0:sprite명1:체력2:공격력3:공격방식4:공격범위5:이동속도6:공격속도7:비용8:보상9
                data.Add(tmp[0], new UnitInfo(int.Parse(tmp[3]), int.Parse(tmp[2]), float.Parse(tmp[5]), float.Parse(tmp[7]), float.Parse(tmp[6]), int.Parse(tmp[9]), true));
            }

            if (data.ContainsKey(tmp[0]))
            {
                Debug.Log(data[tmp[0]]);
            }
            else
            {
                Debug.Log("Error! : " + t);
            }
        }
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
