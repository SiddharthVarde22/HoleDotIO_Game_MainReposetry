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
    AsyncOperation loadingSceneOperation = null;

    [SerializeField]
    Text scoreText, timerText, GameOverText;
    [SerializeField]
    Image loadingImage;

    [SerializeField]
    GameObject gameOverPanel, buttonPanelRefrence, LoadingPanelRefrence;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerHoleRefrence = FindObjectOfType<Hole>();
        if (LoadingPanelRefrence != null)
        {
            LoadingPanelRefrence.SetActive(false);
        }
        if(buttonPanelRefrence != null)
        {
            buttonPanelRefrence.SetActive(true);
        }

        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            TimerUpdate();
            ScoreUpdate();
        }

        if(loadingSceneOperation != null)
        {
            loadingImage.fillAmount = loadingSceneOperation.progress;
        }
    }

    public void OnPlayPressed()
    {
        // load gameplay scene
        loadingSceneOperation =  SceneManager.LoadSceneAsync(1);
        if(buttonPanelRefrence != null)
        {
            buttonPanelRefrence.SetActive(false);
        }
        if(LoadingPanelRefrence != null)
        {
            LoadingPanelRefrence.SetActive(true);
        }
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnOkayPressed()
    {
        //load main menu
        SceneManager.LoadScene(0);
    }

    void TimerUpdate()
    {
        if (timerText != null)
        {
            seconds -= Time.deltaTime;
            if (seconds < 1)
            {
                minutes--;
                if (minutes < 0)
                {
                    //Game Over
                    if (gameOverPanel != null)
                    {
                        Time.timeScale = 0;
                        gameOverPanel.SetActive(true);
                        if(GameOverText != null)
                        {
                            GameOverText.text = "Game Over \n You Scored : "
                                + playerHoleRefrence.totalScore + " Points";
                        }
                    }
                }
                seconds = 60;
            }
            timerText.text = minutes + " : " + (int)seconds;
        }
    }

    void ScoreUpdate()
    {
        //Display Score
        if (scoreText != null)
        {
            scoreText.text = "" + playerHoleRefrence.totalScore;
        }
    }
}
