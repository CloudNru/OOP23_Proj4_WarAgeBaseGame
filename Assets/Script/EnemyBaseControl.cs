using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseControl : MonoBehaviour
{
    private Vector3 awayBaseVec = new Vector3(24, -3f, -1);
    public UnitFactory unitFactory;
    private int totalGold = 0;
    private int currentLV = 1;
    private int cost = 100;
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
            if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("CEnemy"))
            {
                unitFactory.CreateMonster("CEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("CEnemy");
            }
        }
        else if(currentLV == 2)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("CEnemy")&&spawnState == 1)
            {
                unitFactory.CreateMonster("CEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("CEnemy");
                spawnState = Random.Range(1, 2);
            }
            else if(GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("C#Enemy") && spawnState == 2)
            {
                unitFactory.CreateMonster("C#Enemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("C#Enemy");
                spawnState = Random.Range(1, 2);
            }

        }
        else if(currentLV == 3)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("FlutterEnemy") && spawnState == 1)
            {
                unitFactory.CreateMonster("FlutterEnemy", awayBaseVec, true);
                totalGold +=unitFactory.getUnitCost("FlutterEnemy");
                spawnState = Random.Range(1, 3);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold +unitFactory.getUnitCost("LinuxEnemy") && spawnState == 2)
            {
                unitFactory.CreateMonster("LinuxEnemy", awayBaseVec, true);
                totalGold +=unitFactory.getUnitCost("LinuxEnemy");
                spawnState = Random.Range(1, 3);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("C#Enemy") && spawnState == 3)
            {
                unitFactory.CreateMonster("C#Enemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("C#Enemy");
                spawnState = Random.Range(1, 3);
            }
        }
        else if(currentLV == 4)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("CEnemy") && spawnState == 1)
            {
                unitFactory.CreateMonster("CEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("CEnemy");
                spawnState = Random.Range(1, 4);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("LearningXEnemy") && spawnState == 2)
            {
                unitFactory.CreateMonster("LearningXEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("LearningXEnemy");
                spawnState = Random.Range(1, 4);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold +unitFactory.getUnitCost("PythonEnemy") && spawnState == 3)
            {
                unitFactory.CreateMonster("PythonEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("PythonEnemy");
                spawnState = Random.Range(1, 4);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + unitFactory.getUnitCost("FlutterEnemy") && spawnState == 4)
            {
                unitFactory.CreateMonster("FlutterEnemy", awayBaseVec, true);
                totalGold += unitFactory.getUnitCost("FlutterEnemy");
                spawnState = Random.Range(1, 4);
            }

        }
        
        currentLV = GameManager.Instance.GetLV();
    }
}
