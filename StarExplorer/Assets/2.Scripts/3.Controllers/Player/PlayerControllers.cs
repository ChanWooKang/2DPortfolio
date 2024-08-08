using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public MouseController mouse;

    //플레이어 위치 와 마우스 위치로 바라볼 위치 선정

    void Update()
    {
        GetRotationToMousePoint();
    }

    public void GetRotationToMousePoint()
    {
        mouse.GetMouseWorldPos();
        Vector2 playerPos = transform.position;
        Vector2 goalDirection = (mouse.MouseWorldPos - playerPos).normalized;

        if (goalDirection != Vector2.zero)
        {
            Debug.Log(goalDirection);
            if (goalDirection.x > 0 && goalDirection.y > 0)
            {
                //1사분면
                Debug.Log("1사분면");
            }            
            else if (goalDirection.x < 0 && goalDirection.y > 0)
            {
                //2사분면
                Debug.Log("2사분면");
            }
            else if (goalDirection.x < 0 && goalDirection.y < 0)
            {
                //3사분면
                Debug.Log("3사분면");
            }
            else if (goalDirection.x > 0 && goalDirection.y < 0)
            {
                //4사분면
                Debug.Log("4사분면");
            }
        }
    }
}
