using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _uniqueInstance;
    static Managers _inst { get { Init(); return _uniqueInstance; } }

    #region [ Core ] 
    FileManager File = new FileManager();
    InputManager Input = new InputManager();

    public static FileManager _file { get { return _inst.File; } }
    public static InputManager _input { get { return _inst.Input; } }
    #endregion [ Core ]
    const string ObjName = "@Managers";

    static void Init()
    {
        if(_uniqueInstance == null)
        {
            GameObject go = GameObject.Find(ObjName);
            if(go == null)
            {
                go = new GameObject { name = ObjName };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            _uniqueInstance = go.GetComponent<Managers>();

            _uniqueInstance.File.Init();
            _uniqueInstance.Input.Init();
        }
    }

    void Update()
    {
        _input.OnUpdate();
    }

    public void Clear()
    {
        _input.Clear();
    }
}
