using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Countdown : MonoBehaviour
{
    private int maxTime;
    private int currentTime;

    public EventHandler OnTimerChanged;

    private void Start()
    {
        GetFruitTimer(SpawnManager.Instance.GetFruitTime());
        currentTime = maxTime;
        ResumeCountdown();
    }

    public void GetFruitTimer(int fruitLifeTime)
    {
        maxTime = fruitLifeTime;
    }

    public void ResumeCountdown()
    {
        InvokeRepeating("StartCountdown", 1, 1);
    }

    private void StartCountdown()
    {

        if (currentTime > 0)
        {
            currentTime--;
            Mathf.Clamp(currentTime, 0, maxTime);
            OnTimerChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            SpawnManager.Instance.RemoveFruit();
            Destroy(gameObject);
        } 
    }

    public void PauseCountdown()
    {
        CancelInvoke("StartCountdown");
    }

    public int GetCurrentTime()
    {
        return currentTime;
    }
}
