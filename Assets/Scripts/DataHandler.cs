using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.IO;
using Application = UnityEngine.Application;
using System;
using System.Net.Mime;

public static class DataHandler
{
    public static void Save<T>(UnityDirectory unityDirectory, T data, string fileName)
    {
        CheckAndCreateDirectory(GetDirectory(unityDirectory));
        string filePath = GetDirectory(unityDirectory) + Path.AltDirectorySeparatorChar + fileName;
        string jsonData = JsonUtility.ToJson(data);
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        StreamWriter streamWriter = new StreamWriter(fileStream);
        streamWriter.Write(jsonData);
        streamWriter.Close();
        fileStream.Close();
    }

    public enum UnityDirectory
    {
        StreamingAsset, PersistentData, DataPath, TemporaryCachePath
    }

    public static T Load<T>(UnityDirectory unityDirectory, string fileName)
    {
        CheckAndCreateDirectory(GetDirectory(unityDirectory));
        string filePath = GetDirectory(unityDirectory) + Path.AltDirectorySeparatorChar + fileName;
        if (!CheckFile(filePath)) throw new Exception("Cannot load" + fileName);
        StreamReader sr = new StreamReader(filePath);
        string jsonData = sr.ReadToEnd();
        sr.Close();
        
        return JsonUtility.FromJson<T>(jsonData);
    }

    public static string GetDirectory(UnityDirectory unityDirectory)
    {
        switch (unityDirectory)
        {
            case UnityDirectory.StreamingAsset:
                return Application.streamingAssetsPath;
            case UnityDirectory.PersistentData :
                return Application.persistentDataPath;
            case unityDirectory.DataPath:
                return Application.dataPath;
            case  UnityDirectory.TemporaryCachePath:
                return Application.temporaryCachePath;
            default:
                throw new ArgumentOutOfRangeException(nameof(unityDirectory), unityDirectory, null);
        }
    }

    public static bool CheckAndCreateDirectory(string directoryPath)
    {
        bool isDirectoryExist = File.Exists(directoryPath);
        if (!isDirectoryExist) Directory.CreateDirectory(directoryPath);
        return isDirectoryExist;
    }

    private static bool CheckFile(string filePath)
    {
        bool isFileExists = File.Exists(filePath);
        return isFileExists;
    }
    
    
}
