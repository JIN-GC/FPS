using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject playerObject;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;

    public float timer;

    public Text countdownText;

    int minute;
    int seconds;

    public Color endColor;
    void Start()
    {
        timer = 120.00f;
        mainCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        CountdownTimer();
        ChangeTimerColor();

        if (player.IsDead())
        {
            Destroy(playerObject);
            gameOverCanvas.gameObject.SetActive(true);
        }
    }


    public void OnGameOverButtonClicked()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void CountdownTimer()
    {
        if (timer <= 0.0f)
        {
            return;
        }
        timer -= Time.deltaTime;
        minute = (int)timer / 60;
        seconds = (int)timer % 60;

        countdownText.text = string.Format("{0}:{1}", minute, seconds);
    }

    public void ChangeTimerColor()
    {
        if (timer <= 30)
        {
            countdownText.color = endColor;
        }
    }
}
