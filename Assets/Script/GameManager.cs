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


    private BaseCamp homeBase;
    private BaseCamp awayBase;
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

        homeBase = unitFactory.CreateBaseCamp(false, homeBaseVec).GetComponent<BaseCamp>();
        awayBase = unitFactory.CreateBaseCamp(true, awayBaseVec).GetComponent<BaseCamp>();
        //StartCoroutine(StartIncrementing());
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = Gold.ToString();
        expText.text = Exp.ToString();

        homeHealthBar.value = homeBase.getHpRatio();
        awayHealthBar.value = awayBase.getHpRatio();

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
        if(homeBase.getHpRatio() == 0)
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
            Debug.Log("Upgrade! Level2");
            homeBase.upgradeImage(1);
            currentLv = 2;
            MaxTime = 450;
        }
        else if(Exp >= 200 && currentLv == 2)
        {
            Debug.Log("Upgrade! Level3");
            currentLv = 3;
            MaxTime = 500;
            homeBase.upgradeImage(2);
        }
        else if(Exp >=300 && currentLv == 3)
        {
            Debug.Log("Upgrade! Level4");
            currentLv = 4;
            MaxTime = 550;
            homeBase.upgradeImage(3);
        }
    }

    public void BuyUnitMelee()
    {
        if (Gold >= unitFactory.getUnitCost("FirstStudentMelee") && currentLv == 1 && unitQueue.Count<5)
        {
            UsedGold += unitFactory.getUnitCost("FirstStudentMelee");
            Gold -= unitFactory.getUnitCost("FirstStudentMelee");
            unitQueue.Enqueue("FirstStudentMelee");
        }
        else if (Gold >= unitFactory.getUnitCost("SecondStudentMelee") && currentLv == 2 && unitQueue.Count < 5)
        {
            UsedGold += unitFactory.getUnitCost("SecondStudentMelee");
            Gold -= unitFactory.getUnitCost("SecondStudentMelee");
            unitQueue.Enqueue("SecondStudentMelee");
        }
        else if (Gold >= unitFactory.getUnitCost("ThirdStudentMelee") && currentLv == 3 && unitQueue.Count < 5)
        {

            UsedGold += unitFactory.getUnitCost("ThirdStudentMelee");
            Gold -= unitFactory.getUnitCost("ThirdStudentMelee");
            unitQueue.Enqueue("ThirdStudentMelee");
        }
        else if(Gold >= unitFactory.getUnitCost("FourthStudentMelee") && currentLv == 4 && unitQueue.Count < 5)
        {

            UsedGold += unitFactory.getUnitCost("FourthStudentMelee");
            Gold -= unitFactory.getUnitCost("FourthStudentMelee");
            unitQueue.Enqueue("FourthStudentMelee");
        }
    }
    public void BuyUnitRange()
    {
        if (Gold >= unitFactory.getUnitCost("FirstStudentRange") && currentLv == 1 && unitQueue.Count < 5)
        {
            UsedGold += unitFactory.getUnitCost("FirstStudentRange");
            Gold -= unitFactory.getUnitCost("FirstStudentRange");
            unitQueue.Enqueue("FirstStudentRange");
        }
        else if (Gold >= unitFactory.getUnitCost("SecondStudentRange") && currentLv == 2 && unitQueue.Count < 5)
        {
            UsedGold += unitFactory.getUnitCost("SecondStudentRange");
            Gold -= unitFactory.getUnitCost("SecondStudentRange");
            unitQueue.Enqueue("SecondStudentRange");
        }
        else if (Gold >= unitFactory.getUnitCost("ThirdStudentRange") && currentLv == 3 && unitQueue.Count < 5)
        {
            UsedGold += unitFactory.getUnitCost("ThirdStudentRange");
            Gold -= unitFactory.getUnitCost("ThirdStudentRange");
            unitQueue.Enqueue("ThirdStudentRange");
        }
        else if (Gold >= unitFactory.getUnitCost("FourthStudentRange") && currentLv == 4 && unitQueue.Count < 5)
        {
            UsedGold += unitFactory.getUnitCost("FourthStudentRange");
            Gold -= unitFactory.getUnitCost("FourthStudentRange");
            unitQueue.Enqueue("FourthStudentRange");
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
        Exp += 10;
    }

    public void killExp(int killExp,bool isEnemy)
    {
        Exp += killExp;
    }

}
