using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class unitInfo
{
    private string unitName;
    private int waitTime;

}
public class GameManager : MonoBehaviour
{
    private float MaxTime = 400f;

    private float curTime = 0f;

    private int Gold = 200;
    private int Exp = 0;
    private int UsedGold = 0;
    private int currentLv = 1;

    private Text goldText;
    private Text expText;
    private Text textUnit;
    private UnitFactory unitFactory;

    private Button restartButton;
    private Slider unitCoolBar;
    private Slider homeHealthBar;
    private Slider awayHealthBar;

    private Vector3 turretVec = new Vector3(-4, -1, -1);
    private Vector3 homeBaseVec = new Vector3(-4, -3f, -1);
    private Vector3 awayBaseVec = new Vector3(24, -3f, -1);
    private Queue<string> unitQueue = new Queue<string>();


    private GameObject homeBase;
    private GameObject awayBase;
    private Image[] unitImg;

    // Start is called before the first frame update

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

        goldText = GameObject.Find("GoldNum").GetComponent<Text>();
        expText = GameObject.Find("ExpNum").GetComponent<Text>();
        textUnit = GameObject.Find("NextUnit").GetComponent<Text>();
        unitCoolBar = GameObject.Find("UnitCoolSlider").GetComponent<Slider>();
        homeHealthBar = GameObject.Find("HealthbarHome").GetComponent<Slider>();
        awayHealthBar = GameObject.Find("HealthbarAway").GetComponent<Slider>();
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        restartButton.gameObject.SetActive(false);

        unitImg = new Image[5];
        unitFactory = GetComponent<UnitFactory>();
        unitFactory.FileLoad();
        
        for (int i = 0; i < 5; i++)
        {
            unitImg[i] = GameObject.Find("UnitImg" + (i + 1)).GetComponent<Image>();
        }

        homeBase = unitFactory.CreateBaseCamp(false, homeBaseVec);
        awayBase = unitFactory.CreateBaseCamp(true, awayBaseVec);
        StartCoroutine(StartIncrementing());
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = Gold.ToString();
        expText.text = Exp.ToString();

        homeHealthBar.value = homeBase.GetComponent<BaseCamp>().getHpRatio();
        awayHealthBar.value = awayBase.GetComponent<BaseCamp>().getHpRatio();

        Debug.Log(unitQueue.Count);

        for (int i = 0; i < unitQueue.Count; i++)
        {
            unitImg[i].color = new Color(1, 129/255f, 129/255f, 1);
        }
        for (int i = unitQueue.Count; i < 5; i++)
        {
            unitImg[i].color = new Color(1, 1, 1, 1);
        }
        if (unitQueue.Count > 0)
        {
            string unitName = unitQueue.Peek();
            textUnit.text = unitName;
            if (curTime == 0)
            {
                curTime = MaxTime;
                
            }
            
            if (curTime == 1)
            {
                unitFactory.CreateMonster(unitQueue.Dequeue(), homeBaseVec, false);
            }
            curTime -= 1;
        }
        if(homeBase.GetComponent<BaseCamp>().getHpRatio() == 0)
        {
            restartButton.gameObject.SetActive(true);

        }
        unitCoolBar.value = curTime / MaxTime;
    }

    IEnumerator StartIncrementing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 2초 대기
            IncreaseValue();
        }
    }



    void IncreaseValue()
    {
        Gold += 100;
        Exp += 100;
    }


    public void UpgradeBase()
    {
        if (Exp >= 100 && currentLv == 1)
        {
            currentLv = 2;
            MaxTime = 450;
        }
        else if(Exp >= 200 && currentLv == 2)
        {
            currentLv = 3;
            MaxTime = 500;
        }
        else if(Exp >=300 && currentLv == 3)
        {
            currentLv = 4;
            MaxTime = 550;
        }
    }

    public void BuyUnitMelee()
    {
        if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 1 && unitQueue.Count<5)
        {
            UsedGold += unitFactory.getUnitCost("FirstStudent");
            Gold -= unitFactory.getUnitCost("FirstStudent");
            unitQueue.Enqueue("FirstStudent");
        }
        else if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 2 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 200;
            Gold -= 200;
            UsedGold += unitFactory.getUnitCost("SecondStudent");
            Gold -= unitFactory.getUnitCost("SecondStudent");
            unitQueue.Enqueue("SecondStudent");
        }
        else if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 3 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 300;
            Gold -= 300;
            UsedGold += unitFactory.getUnitCost("ThirdStudent");
            Gold -= unitFactory.getUnitCost("ThirdStudent");
            unitQueue.Enqueue("ThirdStudent");
        }
        else if(Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 4 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 400;
            Gold -= 400;
            UsedGold += unitFactory.getUnitCost("FourthStudent");
            Gold -= unitFactory.getUnitCost("FourthStudent");
            unitQueue.Enqueue("FourthStudent");
        }
    }
    public void BuyUnitRange()
    {
        if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 1 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 100;
            Gold -= 100;
            UsedGold += unitFactory.getUnitCost("FirstStudent");
            Gold -= unitFactory.getUnitCost("FirstStudent");
            unitQueue.Enqueue("FirstStudent");
        }
        else if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 2 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 200;
            Gold -= 200;
            UsedGold += unitFactory.getUnitCost("FirstStudent");
            Gold -= unitFactory.getUnitCost("FirstStudent");
            unitQueue.Enqueue("SecondStudent");
        }
        else if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 3 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 300;
            Gold -= 300;
            UsedGold += unitFactory.getUnitCost("FirstStudent");
            Gold -= unitFactory.getUnitCost("FirstStudent");
            unitQueue.Enqueue("ThirdStudent");
        }
        else if (Gold >= unitFactory.getUnitCost("FirstStudent") && currentLv == 4 && unitQueue.Count < 5)
        {
<<<<<<< Updated upstream
            UsedGold += 400;
            Gold -= 400;
            UsedGold += unitFactory.getUnitCost("FirstStudent");
            Gold -= unitFactory.getUnitCost("FirstStudent");
            unitQueue.Enqueue("FourthStudent");
        }
    }

    public void BuyTurret()
    {
        if (Gold >= unitFactory.getUnitCost("tower1") && currentLv == 2&&turretVec.y <= 0)
        {
            Gold -= unitFactory.getUnitCost("tower1");
            UsedGold += unitFactory.getUnitCost("tower1");
            unitFactory.CreateTower("tower1",turretVec,false);
            turretVec.y += 1;
        }
        else if (Gold >= unitFactory.getUnitCost("tower2") && currentLv == 3 && turretVec.y <= 1)
        {
            Gold -= unitFactory.getUnitCost("tower2");
            UsedGold += unitFactory.getUnitCost("tower2");
            unitFactory.CreateTower("tower2", turretVec, false);
            turretVec.y += 1;
        }
        else if (Gold >= unitFactory.getUnitCost("tower3") && currentLv ==4 && turretVec.y <= 2)
        {
            Gold -= unitFactory.getUnitCost("tower3");
            UsedGold += unitFactory.getUnitCost("tower3");
            unitFactory.CreateTower("tower3", turretVec, false);
            turretVec.y += 1;
        }
    }

    public int GetUsedGold()
    {
        return UsedGold;
    }

    public int GetLV()
    {
        return currentLv;
    }
    public void killGold(int killGold, bool isEnemy)
    {
        Gold += killGold;
    }

    public void killExp(int killExp,bool isEnemy)
    {
        Exp += killExp;
    }

    public void killExp(Unit enemy)
    {

    }
=======
>>>>>>> Stashed changes


}