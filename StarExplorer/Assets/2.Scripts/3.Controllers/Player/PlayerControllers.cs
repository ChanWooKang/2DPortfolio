using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefineDatas;
public class PlayerControllers : MonoBehaviour
{
    public MouseController mouse;
    public List<GameObject> models;
    //바라보는 각도를 정할 기준 벡터
    eObjectDirecetion playerDirection;
    public eObjectDirecetion PlayerDirection 
    {
        get { return playerDirection; }
        set
        {
            playerDirection = value;
            //Sprite 변경 혹은 GameObject OnOff
            for(int i = 0; i < models.Count; i++)
            {
                if ((int)playerDirection == i)
                    models[i].SetActive(true);
                else
                    models[i].SetActive(false);
            }
        }
    }
    void Start()
    {
        PlayerDirection = eObjectDirecetion.Down;
        Managers._input.KeyAction -= OnKeyEvent;
        Managers._input.KeyAction += OnKeyEvent;
    }

    void Update()
    {
        CheckDirection();
    }

    //마우스 위치에 따라 플레이어가 바라보는 방향 변경
    void CheckDirection()
    {
        eObjectDirecetion direcetion = mouse.GetObjectDirection(transform.position);
        if (playerDirection != direcetion)
        {
            PlayerDirection = direcetion;            
        }
            
    }    

    void OnKeyEvent()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveVelocity = new Vector3(x, y) * 10f * Time.deltaTime;
        this.transform.position += moveVelocity;
    }
}
