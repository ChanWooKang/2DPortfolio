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

        //해당경로에 폴더가 없을 경우 경로 내 폴더 생성
        if (!Directory.Exists(jsonPath))
            Directory.CreateDirectory(jsonPath);
    }

    public void SaveJsonFile<T>(T data, string filename)
    {
        string path = Path.Combine(jsonPath, filename) + JsonSuffix;

        //파일이 존재 할 경우 삭제 후 새로 생성
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
            Debug.Log($"FileManager : ({filename}) 파일을 저장하는데 오류가 발생 했습니다.");
            fs.Close();
        }
    }

    public string LoadJsonFile(string filename)
    {
        string path = Path.Combine(jsonPath, filename) + JsonSuffix;

        //파일이 존재 하지 않을 경우 null값 반환
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
            Debug.Log($"FileManager : ({filename}) 파일을 불러오는데 오류가 발생 했습니다.");
            fs.Close();
            return null;
        }
    }
}
