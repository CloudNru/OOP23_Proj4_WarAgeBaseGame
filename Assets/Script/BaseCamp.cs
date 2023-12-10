using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseCamp : Unit
{
    [SerializeField]
    private List<Sprite> spriteList;

    public void setImageInfo(List<Sprite> sprites)
    {
        if(sprites != null && sprites.Count > 0)
        {
            Destroy(this.gameObject.GetComponent<Animator>());
            spriteList = sprites;
            this.spriteRenderer.sprite = spriteList[0];
            this.spriteRenderer.sortingOrder = 1;
        }
    }

    public void upgradeImage(int level)
    {
        Debug.Log(spriteList.Count);
        this.spriteRenderer.sprite = spriteList[level];
    }

    public override void GetDamaged(int damage)
    {
        if (damage < 0)
            return;

        this.hp -= damage / 2;
    }
}