using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public bool isGameOver = false;
    private int score = 0;
    private float bonusScore = 5000;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI bonusTxt;
    public TextMeshProUGUI highTxt;

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
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreTxt.text = "<color=#ff00ff>SCORE</color> : " + score;
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
}
