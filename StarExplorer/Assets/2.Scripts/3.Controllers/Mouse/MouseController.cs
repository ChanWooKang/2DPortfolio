using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Vector2 MouseWorldPos;

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

    public void GetMouseWorldPos()
    {        
        MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
    }
}
