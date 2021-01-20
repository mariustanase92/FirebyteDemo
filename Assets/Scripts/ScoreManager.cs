using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private FruitTypeSO fruitType;

    public event EventHandler OnPointsEarned;
    private int currentScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentScore = 0;
    }

    public void AddPoint(FruitTypeSO activeFruitType)
    {
        fruitType = activeFruitType;
        currentScore += fruitType.pointsAmount;
        Debug.Log(fruitType.fruitName + ": " + fruitType.pointsAmount);
        Debug.Log("currentScore: " + currentScore);

        OnPointsEarned?.Invoke(this, EventArgs.Empty);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
