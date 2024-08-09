using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineDatas;

public class MouseController : MonoBehaviour
{
    public Vector2 MouseWorldPos;
    // (0.5,0.5) ���� ����
    public Vector2 LinearVec;
    // (-0.5,0.5) ���� ����
    public Vector2 InverseVec;
    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    void Init()
    {
        MouseWorldPos = Vector2.zero;
    }

    float GetSideAngle(Vector2 direction, Vector2 refdirection)
    {
        Vector2 offset = direction - refdirection;
        return Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    }

    public Vector2 GetDirection(Vector2 pos)
    {
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousePoint - pos).normalized;
        return dir;
    }

    public eObjectDirecetion GetObjectDirection(Vector2 pos)
    {
        Vector2 dir = GetDirection(pos);
        eObjectDirecetion direction = eObjectDirecetion.Down;
        //�� ���� �� ���� ���ͷ� ���� ����        
        if (dir == Vector2.zero)
            return direction;

        if (dir.x >= 0 && dir.y >= 0)
        {
            //1��и�
            if (GetSideAngle(dir, LinearVec) >= 0)
                direction = eObjectDirecetion.Up;
            else
                direction = eObjectDirecetion.Right;
        }
        else if (dir.x <= 0 && dir.y >= 0)
        {
            //2��и�
            if (GetSideAngle(dir, -InverseVec) >= 0)
                direction = eObjectDirecetion.Up;
            else
                direction = eObjectDirecetion.Left;
        }
        else if (dir.x <= 0 && dir.y <= 0)
        {
            //3��и�
            if (GetSideAngle(dir, -LinearVec) >= 0)
                direction = eObjectDirecetion.Left;
            else
                direction = eObjectDirecetion.Down;
        }
        else if (dir.x >= 0 && dir.y <= 0) 
        {
            //4��и�
            if (GetSideAngle(dir, InverseVec) >= 0)            
                direction = eObjectDirecetion.Right;           
            else
                direction = eObjectDirecetion.Down;            
        }

        return direction;
    }


}
