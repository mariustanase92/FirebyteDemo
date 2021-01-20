using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoundTimeManager : MonoBehaviour
{
    public static RoundTimeManager Instance { get; private set; }

    public event EventHandler OnRoundTimerChanged;

    [Tooltip("How many seconds does the round last?")]
    [SerializeField] private float maxRoundSeconds = 60;
    private float currentTime;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = maxRoundSeconds;
        InvokeRepeating("StartRoundTimer", 0, 1);
    }

    
    private void StartRoundTimer()
    {
        if(currentTime <= 0)
        {
            GameOverUI.Instance.Show();
            CancelInvoke("StartRoundTimer");
        }
        else
        {
            currentTime--;
            OnRoundTimerChanged?.Invoke(this, EventArgs.Empty);
        }
            
    }

    public float GetRoundTimer()
    {
        return currentTime;
    }
}
