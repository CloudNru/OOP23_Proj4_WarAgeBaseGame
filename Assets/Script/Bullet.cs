using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class Bullet : MonoBehaviour
{
    private Unit target;
    private int power;

    // Update is called once per frame
    void Update()
    {
        if(this.target == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = this.transform.position +  Vector3.Normalize(target.transform.position - this.transform.position) * 4 * Time.deltaTime;
            if (Vector3.Distance(this.transform.position, target.transform.position) <= 1f)
            {
                target.GetDamaged(this.power);
                Destroy(this.gameObject);
            }
        }


        
    }

    public void Setting(Unit unit, int power)
    {
        this.target = unit;
        this.power = power;
    }
}
