using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class RecordKeeper : MonoBehaviour
{
    #region singelton
    public static RecordKeeper Instance;
    
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] bool outPutFile;
    [SerializeField] List<Result> results;

    public void AddResults(string testName, string initTime, float avgFPS, string AvgUpdateLenght, int numberOfObjects)
    {
        Result newResult = new Result()
        {
            testedNumberOfObjects = numberOfObjects,
            name = testName,
            initializationTimeIn_ms = initTime,
            avarageFPS = avgFPS,
            avarageUpdateLenghtIn_ms = AvgUpdateLenght
        };
        results.Add(newResult);
        if(outPutFile)
        {
            AddResultsToFile(newResult);
        }


    }

    private void AddResultsToFile(Result newResult)
    {
        if (!Directory.Exists($"{Application.persistentDataPath}/Results"))
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/Results");
        }
        string filePath = $"{Application.persistentDataPath}/Results/Results.txt";
        string contentToAdd = JsonUtility.ToJson(newResult);

        try
        {
            File.AppendAllText(filePath, $"{contentToAdd}\n");
        }
        catch (Exception e)
        {
            Debug.LogError($"{e.Message}\n {e.StackTrace}");
        }
    }
}

[Serializable]
public struct Result
{
    public int testedNumberOfObjects;
    public string name;
    public string initializationTimeIn_ms;
    public float avarageFPS;
    public string avarageUpdateLenghtIn_ms;
    
}
