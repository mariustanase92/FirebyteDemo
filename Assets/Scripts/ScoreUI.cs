using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
        ScoreManager.Instance.OnPointsEarned += ScoreManager_OnPointsEarned;   
    }

    private void ScoreManager_OnPointsEarned(object sender, System.EventArgs e)
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
    }

}
