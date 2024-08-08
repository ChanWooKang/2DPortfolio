using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class FileManager
{
    const string JsonSuffix = ".json";
    string jsonPath = null;

    public void Init()
    {
#if UNITY_EDITOR
        jsonPath = Application.dataPath + "/8.Daatas/Json";
#else
        jsonPath = Application.persistentDataPath + "/Json";
#endif

        //�ش��ο� ������ ���� ��� ��� �� ���� ����
        if (!Directory.Exists(jsonPath))
            Directory.CreateDirectory(jsonPath);
    }

    public void SaveJsonFile<T>(T data, string filename)
    {
        string path = Path.Combine(jsonPath, filename) + JsonSuffix;

        //������ ���� �� ��� ���� �� ���� ����
        if (File.Exists(path))
            File.Delete(path);

        FileStream fs = new FileStream(path, FileMode.Create);
        try
        {
            string jsonData = JsonUtility.ToJson(data, true);
            byte[] datas = Encoding.UTF8.GetBytes(jsonData);
            fs.Write(datas, 0, datas.Length);
            fs.Close();
        }
        catch
        {
            Debug.Log($"FileManager : ({filename}) ������ �����ϴµ� ������ �߻� �߽��ϴ�.");
            fs.Close();
        }
    }

    public string LoadJsonFile(string filename)
    {
        string path = Path.Combine(jsonPath, filename) + JsonSuffix;

        //������ ���� ���� ���� ��� null�� ��ȯ
        if (!File.Exists(path))
            return null;

        FileStream fs = new FileStream(path, FileMode.Open);
        try
        {
            byte[] datas = new byte[fs.Length];
            fs.Read(datas, 0, datas.Length);            
            fs.Close();
            string jsonData = Encoding.UTF8.GetString(datas);
            return jsonData;
        }
        catch
        {
            Debug.Log($"FileManager : ({filename}) ������ �ҷ����µ� ������ �߻� �߽��ϴ�.");
            fs.Close();
            return null;
        }
    }
}
