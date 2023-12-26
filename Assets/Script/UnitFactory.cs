using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.Sprites;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject unitBaseObject;

    private Dictionary<string, UnitInfo> data;
    private UnitInfo BaseCamp;
    private Dictionary<string, List<Sprite>> spriteList;

    public void FileLoad()
    {
        data = new Dictionary<string, UnitInfo>();
        spriteList = new Dictionary<string, List<Sprite>>();
        Regex regex = new Regex(@"BaseCamp_\d\d\d");
        unitBaseObject = (GameObject)Resources.Load("UnitBase");
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
            if (regex.IsMatch(tmp[0]))
            {
                string[] textureTexts = tmp[1].Split('/');
                List<Sprite> sprites = new List<Sprite>();
                foreach (string textureText in textureTexts)
                {
                    if(File.Exists("Assets/Resource/" + textureText))
                    {
                        byte[] TextureData = File.ReadAllBytes("Assets/Resource/" + textureText);
                        Texture2D texture = new Texture2D(1, 1);
                        texture.LoadImage(TextureData);
                        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 250);
                        if (sprite != null)
                        {
                            sprites.Add(sprite);
                        }
                    }
                }

                spriteList.Add(tmp[0], sprites);

                BaseCamp = new UnitInfo(tmp[0], null, int.Parse(tmp[2]), int.Parse(tmp[3]), tmp[4] == "Near" ? true : false, float.Parse(tmp[5]), float.Parse(tmp[6]), float.Parse(tmp[7]), int.Parse(tmp[8]), int.Parse(tmp[9]));
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
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 500);

                    data.Add(tmp[0], new UnitInfo(tmp[0], sprite, int.Parse(tmp[2]), int.Parse(tmp[3]), tmp[4] == "Near" ? true : false, float.Parse(tmp[5]), float.Parse(tmp[6]), float.Parse(tmp[7]), int.Parse(tmp[8]), int.Parse(tmp[9])));
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
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 250);

                    TextureData = File.ReadAllBytes("Assets/Resource/" + tmp[10]);
                    texture = new Texture2D(1, 1);
                    texture.LoadImage(TextureData);
                    Sprite bulletSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1000);

                    data.Add(tmp[0], new UnitInfo(tmp[0], sprite, int.Parse(tmp[2]), int.Parse(tmp[3]), tmp[4] == "Near" ? true : false, float.Parse(tmp[5]), float.Parse(tmp[6]), float.Parse(tmp[7]), int.Parse(tmp[8]), int.Parse(tmp[9]), bulletSprite));
                    Debug.Log(tmp[8]);
                }
            }

            if (data.ContainsKey(tmp[0]))
            {
                Debug.Log(tmp[0] + " " + data[tmp[0]].cost);
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
        if (data[name].isNear)
        {
            Monster monster = obj.AddComponent<Monster>();
            monster.Setting(data[name], new StudentStateControler(monster), isRightTeam);
        }
        else
        {
            BackMonster monster = obj.AddComponent<BackMonster>();
            monster.Setting(data[name], null, isRightTeam);
        }
        obj.SetActive(true);
        return obj;
    }

    public GameObject CreateBaseCamp(string campName, bool isRightTeam)
    {
        return CreateBaseCamp(campName, isRightTeam, Vector3.zero);
    }

    public GameObject CreateBaseCamp(string campName, bool isRightTeam, Vector3 position)
    {
        if (!spriteList.ContainsKey(campName))
        {
            return null;
        }

        GameObject obj = Instantiate(unitBaseObject, position, Quaternion.Euler(Vector3.up * (isRightTeam ? 180 : 0)));
        BaseCamp baseCamp = obj.AddComponent<BaseCamp>();
        baseCamp.Setting(BaseCamp, null, isRightTeam);
        
        Animator animator = baseCamp.gameObject.AddComponent<Animator>();
        baseCamp.setImageInfo(spriteList[campName]);
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
        baseCamp.setImageInfo(spriteList[isRightTeam ? "BaseCamp_310" : "BaseCamp_208"]);
        obj.AddComponent<BoxCollider2D>().isTrigger = true;
        obj.name = isRightTeam ? "BaseCamp_310" : "BaseCamp_208";
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
        this.transform.localScale = new Vector3(10, 10, 5);
        Tower tower = obj.AddComponent<Tower>();
        tower.Setting(data[name], new TowerStateController(tower), isRightTeam);
        obj.SetActive(true);
        return obj;
    }

    public int getUnitCost(String unitName)
    {
        if(unitName == null || !data.ContainsKey(unitName))
        {
            return -1;
        }
        Debug.Log(unitName + "'s cost : " + data[unitName].cost);
        return data[unitName].cost;
    }
}