using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public MouseController mouse;

    //�÷��̾� ��ġ �� ���콺 ��ġ�� �ٶ� ��ġ ����

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
                //1��и�
                Debug.Log("1��и�");
            }            
            else if (goalDirection.x < 0 && goalDirection.y > 0)
            {
                //2��и�
                Debug.Log("2��и�");
            }
            else if (goalDirection.x < 0 && goalDirection.y < 0)
            {
                //3��и�
                Debug.Log("3��и�");
            }
            else if (goalDirection.x > 0 && goalDirection.y < 0)
            {
                //4��и�
                Debug.Log("4��и�");
            }
        }
    }
}
