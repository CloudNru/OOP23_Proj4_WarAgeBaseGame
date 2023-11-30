using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Update is called once per frame
    public float panSpeed = 6f;
    public float panBorderThickness = 10f;
    public float maxX = 20;
    public float minX = 0;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.x >=minX && pos.x <= maxX)
        {
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }
        }
        if(pos.x <= minX)
        {
            pos = new Vector3(minX,0,-10);
        }
        else if (pos.x >= maxX)
        {
            pos = new Vector3(maxX, 0,-10);
        }
        
        transform.position = pos;
    }
}
