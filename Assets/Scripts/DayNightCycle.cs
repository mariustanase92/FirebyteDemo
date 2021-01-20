using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; //lights for now
using UnityEngine.Rendering.Universal; //lights in the future

public class DayNightCycle : MonoBehaviour {

   [SerializeField] private Gradient gradient;
   [SerializeField] private float secondsPerDay = 10f;
    private Light2D light2d;
    private float dayTime;
    private float dayTimeSpeed;

    private void Awake() {
        light2d = GetComponent<Light2D>();
        dayTimeSpeed = 1 / secondsPerDay;
    }

    private void Update() {
        dayTime += Time.deltaTime * dayTimeSpeed;
        light2d.color = gradient.Evaluate(dayTime % 1f); //select a few locations from the Gradient color
        //% to normalize from 0 to 1, if it goes past 1f, it resets to 0f thanks to module
    }
}
