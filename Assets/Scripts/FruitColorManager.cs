using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using System;

public class FruitColorManager : MonoBehaviour
{
    private Countdown countDown;
    private SpriteRenderer fruitSprite;
    private Color fullColor;
    private Color previousColor;

    private void Awake()
    {
        countDown = GetComponent<Countdown>();
        fruitSprite = GetComponent<SpriteRenderer>();
        fullColor = fruitSprite.color;
    }

    private void Start()
    {
        fruitSprite.color = fullColor;
        countDown.OnTimerChanged += Countdown_TimerChanged;
    }

    private void Countdown_TimerChanged(object sender, System.EventArgs e)
    {
        previousColor = new Color(1, 1, 1, (fruitSprite.color.a - .1f));
        fruitSprite.color = previousColor;
    }

    public void ReturnToPreviousColor()
    {
        fruitSprite.color = previousColor;
    }

    public void ResetFruitColor()
    {
        fruitSprite.color = fullColor;
    }
}
