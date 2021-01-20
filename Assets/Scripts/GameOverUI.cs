using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour {

    public static GameOverUI Instance { get; private set; }

    private void Awake() {
        Instance = this;
        transform.Find("retryBtn").GetComponent<Button>().onClick.AddListener(() => {
            GameSceneManager.Load(GameSceneManager.Scene.Firebyte);
        });

        transform.Find("mainMenuBtn").GetComponent<Button>().onClick.AddListener(() => {
            GameSceneManager.Load(GameSceneManager.Scene.MainMenuScene);
        });

        Hide();
    }

    public void Show() {
        gameObject.SetActive(true);

        transform.Find("scoreText").GetComponent<TextMeshProUGUI>().
            SetText("Your Score: " + ScoreManager.Instance.GetCurrentScore());

        SoundManager.Instance.PlaySound(SoundManager.Sound.GameOver);

        if (gameObject.activeSelf)
        {
            Time.timeScale = 0f; //pause
        }
        else
        { 
            Time.timeScale = 1f; //unpause
        }
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
