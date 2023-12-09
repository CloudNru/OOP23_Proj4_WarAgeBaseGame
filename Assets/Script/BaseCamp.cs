using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamp : Unit
{
    private List<Sprite> spriteList;

    public void setImage(Sprite[] sprites)
    {

    }

    public void upgradeImage(int level)
    {
        if(level < 0 || level >= spriteList.Count)
        {
            return;
        }

        this.spriteRenderer.sprite = spriteList[level];
    }
}