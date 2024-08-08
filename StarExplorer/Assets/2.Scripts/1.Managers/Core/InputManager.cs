using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using DefineDatas;

public class InputManager
{
    public Action<eMouseEvent> MouseAction;
    public Action KeyAction;
    bool isPress;
    float pressTime;
    float tick;

    public void Init()
    {
        MouseAction = null;
        KeyAction = null;
        isPress = false;
        pressTime = 0;
        tick = 0.25f;
    }

    public void OnUpdate()
    {

        //RayCastTarget On �Ǿ��ִ�  UI������ �۵� X
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //KeyAction
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        //MouseAction
        if(MouseAction != null)
        {
            //���콺 Action �� ��Ŭ���� ����
            if (Input.GetMouseButton(0))
            {
                if(isPress == false)
                {
                    MouseAction.Invoke(eMouseEvent.PointerDown);
                    pressTime = Time.time;
                }
                MouseAction.Invoke(eMouseEvent.Press);
                isPress = true;
            }
            else
            {
                if (isPress)
                {
                    if(Time.time > pressTime + tick)
                        MouseAction.Invoke(eMouseEvent.Click);
                    MouseAction.Invoke(eMouseEvent.PointerUP);
                }
                isPress = false;
                pressTime = 0;
            }
        }
    }

    public void Clear()
    {
        MouseAction = null;
        KeyAction = null;
        isPress = false;
        pressTime = 0;
    }
}
