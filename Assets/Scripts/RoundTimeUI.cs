using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundTimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundTimeText;

    void Start()
    {
        roundTimeText.text = RoundTimeManager.Instance.GetRoundTimer().ToString();
        RoundTimeManager.Instance.OnRoundTimerChanged += TimeManager_OnRoundTimerChanged;
    }

    private void TimeManager_OnRoundTimerChanged(object sender, System.EventArgs e)
    {
        roundTimeText.text = RoundTimeManager.Instance.GetRoundTimer().ToString();
    }

}
