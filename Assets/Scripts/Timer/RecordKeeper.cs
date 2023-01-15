using System;
using System.Collections.Generic;
using UnityEngine;


    public class RecordKeeper : MonoBehaviour
    {
        public static RecordKeeper Instance;
        private void Awake()
        {
            Instance = this;
        }

    [SerializeField] List<Result> results;

    public void AddResults(string testName,string initTime, float avgFPS, string AvgUpdateLenght)
    {
        Result newResult = new Result() {
            name = testName,
            initializationTimeIn_ms = initTime,
            avarageFPS = avgFPS,
            avarageUpdateLenghtIn_ms = AvgUpdateLenght
        };
        results.Add(newResult);
      

    }

    }

[Serializable]
public struct Result
{
    public string name;
    public string initializationTimeIn_ms;
    public float avarageFPS;
    public string avarageUpdateLenghtIn_ms;
}
