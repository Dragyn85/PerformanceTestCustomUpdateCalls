using ObserverManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    public static event Action OnAnyTestCompleted;

    FPSTimer timer;
    readonly float testLenght = 10;
    float elaspedTime;
    bool shouldMesure;


    private void OnEnable()
    {
        elaspedTime = 0;
        shouldMesure = true;
        timer = new FPSTimer();
    }
    void Update()
    {
        elaspedTime += Time.deltaTime;
        if (timer.IsRunning)
        {
            timer.Update();
            if (elaspedTime > testLenght)
            {
                timer.StopTimer();
                shouldMesure = false;

                StatDisplay.Instance.SetAvarageFpsText(timer.GetAvarageFramePerSecond().ToString());
                StatDisplay.Instance.SetAvarageUpdateLenghtText(timer.GetAvarageFrameLenghtInMS().ToString());
                StatDisplay.Instance.HideRunningStatus();
                var amountOfObejects = StatDisplay.Instance.GetNumberOfObjects();
                string initTime = StatDisplay.Instance.GetInitTime();
                RecordKeeper.Instance.AddResults(gameObject.name, initTime, timer.GetAvarageFramePerSecond(),timer.GetAvarageFrameLenghtInMS().ToString(),amountOfObejects);
                OnAnyTestCompleted?.Invoke();
            }
        }
        else if (shouldMesure)
        {
            timer.StartTimer();
        }

    }
}
