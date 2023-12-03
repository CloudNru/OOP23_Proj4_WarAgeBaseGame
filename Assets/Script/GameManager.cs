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
    private float MaxHealth = 100;

    private float curTime = 0f;

    private float homeHealth = 100;
    private float awayHealth = 100;

    private int Gold = 0;
    private int Exp = 0;

    private int currentLv = 1;

    private Text goldText;
    private Text expText;

    private UnitFactory unitFactory;
    [SerializeField]
    private GameObject homeBase;
    [SerializeField]
    private GameObject awayBase;

    private Slider unitCoolBar;
    private Slider homeHealthBar;
    private Slider awayHealthBar;
    public Queue<string> unitQueue = new Queue<string>();

    public Image[] unitImg;

    // Start is called before the first frame update
    void Start()
    {
        goldText = GameObject.Find("GoldNum").GetComponent<Text>();
        expText = GameObject.Find("ExpNum").GetComponent<Text>();
        unitCoolBar = GameObject.Find("UnitCoolSlider").GetComponent<Slider>();
        homeHealthBar = GameObject.Find("HealthbarHome").GetComponent<Slider>();
        awayHealthBar = GameObject.Find("HealthbarAway").GetComponent<Slider>();
        unitImg = new Image[5];
        unitFactory = GetComponent<UnitFactory>();

        for(int i = 0; i < 5; i++)
        {
            unitImg[i] = GameObject.Find("UnitImg" + (i + 1)).GetComponent<Image>();
        }
        homeBase = unitFactory.CreateBaseCamp(false,new Vector3(-4,-4.5f,0));
        awayBase = unitFactory.CreateBaseCamp(true, new Vector3(24, -4.5f, 0));
        StartCoroutine(StartIncrementing());

    }

    // Update is called once per frame
    void Update()
    {

        goldText.text = Gold.ToString();
        expText.text = Exp.ToString();

        homeHealthBar.value = homeHealth / MaxHealth;
        awayHealthBar.value = awayHealth / MaxHealth;

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
            
            if (curTime == 0)
            {
                curTime = 400;
            }
            
            if (curTime == 1)
            {
                unitQueue.Dequeue();
            }
            curTime -= 1;
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

    IEnumerator unitCool(int time)
    {
        yield return new WaitForSeconds(time);
        unitFactory.CreateMonster(unitQueue.Dequeue());

    }

    void IncreaseValue()
    {
        Gold += 100;
        Exp += 100;
    }

    void AddUnit(string name)
    {
        if(currentLv == 1)
        {
            unitQueue.Enqueue("lv1Unit");
        }
    }

    public void UpgradeBase()
    {
        if (Exp >= 100 && currentLv == 1)
        {
            currentLv = 2;
        }
        else if(Exp >= 200 && currentLv == 2)
        {
            currentLv = 3;
        }
        else if(Exp >=300 && currentLv == 3)
        {
            currentLv = 4;
        }
    }

    public void BuyUnit()
    {
        if (Gold >= 100 && currentLv == 1 && unitQueue.Count<5)
        {
            Gold -= 100;
            unitQueue.Enqueue("LV1");
        }
        else if (Gold >= 200 && currentLv == 2 && unitQueue.Count < 5)
        {
            Gold -= 200;
            unitQueue.Enqueue("LV2");
        }
        else if (Gold >= 300 && currentLv == 3 && unitQueue.Count < 5)
        {
            Gold -= 300;
            unitQueue.Enqueue("LV3");
        }
        else if(Gold >= 400 && currentLv == 4 && unitQueue.Count < 5)
        {
            Gold -= 400;
            unitQueue.Enqueue("LV4");
        }
    }

    public void BuyTurret()
    {

    }
}
