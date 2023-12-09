using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Sprites;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject unitBaseObject;

    private Dictionary<string, UnitInfo> data;
    private UnitInfo BaseCamp;

    public void FileLoad()
    {
        data = new Dictionary<string, UnitInfo>();
        if (File.Exists("Assets/Prefab/UnitBase.prefab"))
        {
            unitBaseObject = PrefabUtility.LoadPrefabContents("Assets/Prefab/UnitBase.prefab");
        }
        string[] datas = new string[0];
        if (File.Exists("Assets/DataFile/DataText.txt"))
        {
            datas = File.ReadAllLines("Assets/DataFile/DataText.txt");
        }
        foreach (string t in datas)
        {
            if(t == "//*")
            {
                continue;
            }

            string[] tmp = t.Split(':');
            if (tmp[0] == "BaseCamp")
            {
                byte[] TextureData = File.ReadAllBytes("Assets/Resource/" + tmp[1]);
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(TextureData);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 2000);

                BaseCamp = new UnitInfo(tmp[0], sprite, int.Parse(tmp[2]), int.Parse(tmp[3]), tmp[4] == "Near" ? true : false, float.Parse(tmp[5]), float.Parse(tmp[6]), float.Parse(tmp[7]), int.Parse(tmp[9]));
                Debug.Log(tmp[0] + " " + BaseCamp);
            }
            else if (tmp.Length == 10)
            {
                //이름0:sprite명1:체력2:공격력3:공격방식4:공격범위5:이동속도6:공격속도7:비용8:보상9
                if (File.Exists("Assets/Resource/" + tmp[1]))
                {
                    byte[] TextureData = File.ReadAllBytes("Assets/Resource/" + tmp[1]);
                    Texture2D texture = new Texture2D(1, 1);
                    texture.LoadImage(TextureData);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 2000);

                    data.Add(tmp[0], new UnitInfo(tmp[0], sprite, int.Parse(tmp[2]), int.Parse(tmp[3]), tmp[4] == "Near" ? true : false, float.Parse(tmp[5]), float.Parse(tmp[6]), float.Parse(tmp[7]), int.Parse(tmp[9])));
                }
            }
            else if (tmp.Length == 11)
            {
                //이름0:sprite명1:체력2:공격력3:공격방식4:공격범위5:이동속도6:공격속도7:비용8:보상9:총알sprite명10
                if (File.Exists("Assets/Resource/" + tmp[1]) && File.Exists("Assets/Resource/" + tmp[10]))
                {
                    byte[] TextureData = File.ReadAllBytes("Assets/Resource/" + tmp[1]);
                    Texture2D texture = new Texture2D(1, 1);
                    texture.LoadImage(TextureData);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 2000);

                    TextureData = File.ReadAllBytes("Assets/Resource/" + tmp[10]);
                    texture = new Texture2D(1, 1);
                    texture.LoadImage(TextureData);
                    Sprite bulletSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 300);

                    data.Add(tmp[0], new UnitInfo(tmp[0], sprite, int.Parse(tmp[2]), int.Parse(tmp[3]), tmp[4] == "Near" ? true : false, float.Parse(tmp[5]), float.Parse(tmp[6]), float.Parse(tmp[7]), int.Parse(tmp[9]), bulletSprite));
                }
            }

            if (data.ContainsKey(tmp[0]))
            {
                Debug.Log(tmp[0] + " " + data[tmp[0]]);
            }
        }
    }

    public GameObject CreateMonster(string name, bool isRightTeam)
    {
        return CreateMonster(name, Vector3.zero, isRightTeam);        
    }

    public GameObject CreateMonster(string name, Vector3 position, bool isRightTeam)
    {
        if (!data.ContainsKey(name))
        {
            Debug.Log("Error!");
            return null; 
        }

        GameObject obj = Instantiate(unitBaseObject, position, Quaternion.Euler(Vector3.up * (isRightTeam ? 180 : 0)));
        Monster monster = obj.AddComponent<Monster>();
        monster.Setting(data[name], new StudentStateControler(monster), isRightTeam);
        obj.SetActive(true);
        return obj;
    }

    public GameObject CreateBaseCamp(bool isRightTeam)
    {
        return CreateBaseCamp(isRightTeam, Vector3.zero);
    }

    public GameObject CreateBaseCamp(bool isRightTeam, Vector3 position)
    {
        GameObject obj = Instantiate(unitBaseObject, position, Quaternion.Euler(Vector3.up * (isRightTeam ? 180 : 0)));
        BaseCamp baseCamp = obj.AddComponent<BaseCamp>();
        baseCamp.Setting(BaseCamp, null, isRightTeam);
        obj.SetActive(true);

        return obj;
    }

    public GameObject CreateTower(string name, bool isRightTeam)
    {
        return CreateTower(name, Vector3.zero, isRightTeam);
    }

    public GameObject CreateTower(string name, Vector3 position, bool isRightTeam)
    {
        if (!data.ContainsKey(name))
        {
            Debug.Log("Error!");
            return null;
        }

        GameObject obj = Instantiate(unitBaseObject, position, Quaternion.Euler(Vector3.up * (isRightTeam ? 180 : 0)));
        Tower tower = obj.AddComponent<Tower>();
        tower.Setting(data[name], new TowerStateController(tower), isRightTeam);
        obj.SetActive(true);
        return obj;
    }
}
