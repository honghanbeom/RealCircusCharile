using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public bool isGameOver = false;
    private int score = 0;
    private float bonusScore = 10000;

    public GameObject[] life;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI bonusTxt;
    public TextMeshProUGUI highTxt;
    public TextMeshProUGUI GameOverTxt;
    public TextMeshProUGUI GameClearTxt;
    public TextMeshProUGUI meterTxt;
    private int lifeImageCount = 2;

    public PlayerControl playerControl; 




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("씬에 두개 이상 존재합니다.");
            Destroy(gameObject);    
        }
    }

    // Update is called once per frame
    void Update()
    {

        BonusScore();
        UserMeter();
        if (Input.GetKey(KeyCode.R) == true && isGameOver)
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreTxt.text = "<color=#ff00ff>SCORE</color> : " + score;
        }
    }

    public void UserMeter()
    {
        if (!isGameOver)
        {
            float meter = playerControl.transform.position.x;
            meterTxt.text = "<color=#ff00ff>Meter</color> : " + (int)meter +
                "/<color=#ff00ff>500</color>(m)";
        }
    }


    public void BonusScore()
    {
        if (!isGameOver)
        {
            if (bonusScore > 0)
            {
                bonusScore -= Time.deltaTime * 100f;
                bonusTxt.text = "<color=#ff00ff>BONUS</color> : " + (int)bonusScore;
            }
            if (bonusScore == 0)
            { 
                bonusTxt.text = "<color=#ff00ff>BONUS</color> : " + (int)0;
            }
        }
    }

    public void ReGame()
    {
        life[lifeImageCount].SetActive(false);
        lifeImageCount--;
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            life[0].SetActive(false);
            lifeImageCount--;
            GameOverTxt.gameObject.SetActive(true);

        }
    }

    public void GameClear()
    {
        if (isGameOver)
        {
            GameClearTxt.gameObject.SetActive(true);

        }
    }


}
