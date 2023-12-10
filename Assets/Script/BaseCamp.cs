using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamp : Unit
{
    private List<Sprite> spriteList;

    public void setImageInfo(List<Sprite> sprites)
    {
        if(sprites != null && sprites.Count > 0)
        {
            spriteList = sprites;
            this.spriteRenderer.sprite = spriteList[0];
            this.spriteRenderer.sortingOrder = 1;
        }
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