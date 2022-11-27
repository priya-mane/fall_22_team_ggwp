using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    public Image star1;
    public Image star2;
    public Image star3;
    private Color32 color;
    private Color32 gray;
    int highScore =0;
    public Dictionary < int, int > levelMinLivesMapping = new Dictionary < int, int > ();
    // // Start is called before the first frame update
    void Start()
    {
         mapLives();
        color = new Color32(233, 225, 43, 255);
        gray = new Color32(106, 106, 106, 160);
        if(GameManager.score> PlayerPrefs.GetInt("highScore"+ GameManager.level, 0)){
            PlayerPrefs.SetInt("highScore"+ GameManager.level, GameManager.score);
        }
        highScore = PlayerPrefs.GetInt("highScore"+ GameManager.level, 0);
        
        highScoreText.text = "high score: " + highScore.ToString();
        

        float star = calculateStar();

        GameManager.LevelStarMapping[GameManager.level] = star;

        if(star >= 1f){
            star1.color = color;
        }
        if(star>=2f){
            star1.color = color;
            star2.color = color;
        }
        if(star == 3f){
            star1.color = color;
            star2.color = color;
            star3.color = color; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float calculateStar(){
        int l = getMinLives(GameManager.level);
        float lives = GameManager.lives/(10.0f-l);
        float score = GameManager.score/ (highScore *1.0f);

        return (float) Math.Round((double)(lives + score) * 3 / 2, 2);

    }

    private void mapLives() {
        levelMinLivesMapping[1] = 2;
        levelMinLivesMapping[2] = 0;
        levelMinLivesMapping[3] = 0;
        levelMinLivesMapping[4] = 0;
        levelMinLivesMapping[5] = 0;
        levelMinLivesMapping[6] = 0;
        levelMinLivesMapping[7] = 0;
        levelMinLivesMapping[20] = 0;
        levelMinLivesMapping[8] = 0;
        levelMinLivesMapping[9] = 1;
        levelMinLivesMapping[10] = 0;
        levelMinLivesMapping[16] = 5;
        levelMinLivesMapping[18] = 2;
        levelMinLivesMapping[19] = 1;
        levelMinLivesMapping[15] = 1;
        levelMinLivesMapping[11] = 1;
        levelMinLivesMapping[12] = 2;
        levelMinLivesMapping[13] = 3;
        levelMinLivesMapping[17] = 3;
        levelMinLivesMapping[35] = 3;

    }
    public int getMinLives(int level){
        return levelMinLivesMapping[level];
    }
}

