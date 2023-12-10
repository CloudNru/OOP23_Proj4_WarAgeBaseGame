using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseControl : MonoBehaviour
{
    private Vector3 awayBaseVec = new Vector3(24, -3f, -1);
    public UnitFactory unitFactory;
    private int totalGold = 0;
    private int currentLV = 1;
    private int time = 3000;
    [SerializeField]
    private int spawnState = 1;
    // Update is called once per frame
    private void Start()
    {
        currentLV = GameManager.Instance.GetLV();
        unitFactory = GetComponent<UnitFactory>();
    }
    void Update()
    {
        if(currentLV == 1)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + cost * currentLV)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
            }
        }
        else if(currentLV == 2)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-1)&&spawnState == 1)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
                spawnState = Random.Range(1, 2);
=======
                unitFactory.CreateMonster("CEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("CEnemy");
                spawnState = Random.Range(1, 3);
>>>>>>> Stashed changes
            }
            else if(GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV ) && spawnState == 2)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 1);
                spawnState = Random.Range(1, 2);
=======
                unitFactory.CreateMonster("C#Enemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("C#Enemy");
                spawnState = Random.Range(1, 3);
>>>>>>> Stashed changes
            }

        }
        else if(currentLV == 3)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-2) && spawnState == 1)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 2);
                spawnState = Random.Range(1, 3);
=======
                unitFactory.CreateMonster("FlutterEnemy", awayBaseVec, true);
                totalGold +=unitFactory.getUnitCost("FlutterEnemy");
                spawnState = Random.Range(1, 4);
>>>>>>> Stashed changes
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV -1 ) && spawnState == 2)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 1);
                spawnState = Random.Range(1, 3);
=======
                unitFactory.CreateMonster("LinuxEnemy", awayBaseVec, true);
                totalGold +=unitFactory.getUnitCost("LinuxEnemy");
                spawnState = Random.Range(1, 4);
>>>>>>> Stashed changes
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV) && spawnState == 3)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
                spawnState = Random.Range(1, 3);
=======
                unitFactory.CreateMonster("C#Enemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("C#Enemy");
                spawnState = Random.Range(1, 4);
>>>>>>> Stashed changes
            }
        }
        else if(currentLV == 4)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-3) && spawnState == 1)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV-3);
                spawnState = Random.Range(1, 4);
=======
                unitFactory.CreateMonster("CEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("CEnemy");
                spawnState = Random.Range(1, 5);
>>>>>>> Stashed changes
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-2) && spawnState == 2)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 2);
                spawnState = Random.Range(1, 4);
=======
                unitFactory.CreateMonster("LearningXEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("LearningXEnemy");
                spawnState = Random.Range(1, 5);
>>>>>>> Stashed changes
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-1) && spawnState == 3)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 1);
                spawnState = Random.Range(1, 4);
=======
                unitFactory.CreateMonster("PythonEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("PythonEnemy");
                spawnState = Random.Range(1, 5);
>>>>>>> Stashed changes
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV) && spawnState == 4)
            {
<<<<<<< Updated upstream
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
                spawnState = Random.Range(1, 4);
=======
                unitFactory.CreateMonster("FlutterEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("FlutterEnemy");
                spawnState = Random.Range(1, 5);
>>>>>>> Stashed changes
            }

        }
        time -= 1;
        if(time == 0)
        {
            time = 3000;
            totalGold -= Random.Range(10, 21);

        }
        currentLV = GameManager.Instance.GetLV();
    }
}
