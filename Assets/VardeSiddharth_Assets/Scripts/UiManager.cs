using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    int minutes = 1;
    [SerializeField]
    float seconds = 60;

    Hole playerHoleRefrence;

    [SerializeField]
    Text scoreText, timerText;

    [SerializeField]
    GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerHoleRefrence = FindObjectOfType<Hole>();

        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
        ScoreUpdate();
    }

    public void OnPlayPressed()
    {
        // load gameplay scene
        SceneManager.LoadScene(1);
    }

    public void OnOkayPressed()
    {
        //load main menu
        SceneManager.LoadScene(0);
    }

    void TimerUpdate()
    {
        seconds -= Time.deltaTime;
        if(seconds < 1)
        {
            minutes--;
            if(minutes < 0)
            {
                //Game Over
                if (gameOverPanel != null)
                {
                    Time.timeScale = 0;
                    gameOverPanel.SetActive(true);
                }
            }
            seconds = 60;
        }
        timerText.text = "Time : " + minutes + " : " + (int)seconds;
    }

    void ScoreUpdate()
    {
        //Display Score
        scoreText.text = "Score : " + playerHoleRefrence.totalScore;
    }
}
