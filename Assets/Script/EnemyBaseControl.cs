using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseControl : MonoBehaviour
{
    private Vector3 awayBaseVec = new Vector3(24, -4.5f, -1);
    private UnitFactory unitFactory;
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
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
                spawnState = Random.Range(1, 2);
            }
            else if(GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV ) && spawnState == 2)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 1);
                spawnState = Random.Range(1, 2);
            }

        }
        else if(currentLV == 3)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-2) && spawnState == 1)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 2);
                spawnState = Random.Range(1, 3);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV -1 ) && spawnState == 2)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 1);
                spawnState = Random.Range(1, 3);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV) && spawnState == 3)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
                spawnState = Random.Range(1, 3);
            }
        }
        else if(currentLV == 4)
        {
            if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-3) && spawnState == 1)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV-3);
                spawnState = Random.Range(1, 4);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-2) && spawnState == 2)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 2);
                spawnState = Random.Range(1, 4);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV-1) && spawnState == 3)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * (currentLV - 1);
                spawnState = Random.Range(1, 4);
            }
            else if (GameManager.Instance.GetUsedGold() >= totalGold + cost * (currentLV) && spawnState == 4)
            {
                unitFactory.CreateMonster("FirstStudent", awayBaseVec, true);
                totalGold += cost * currentLV;
                spawnState = Random.Range(1, 4);
            }

        }
        
        currentLV = GameManager.Instance.GetLV();
    }
}
