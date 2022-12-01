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
    private Dictionary < int, int > levelMinLivesMapping = new Dictionary < int, int > ();
    private Dictionary < int, int > levelStarsMapping = new Dictionary < int, int > ();
    // // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        mapLives();
        mapStars();
        color = new Color32(233, 225, 43, 255);
        gray = new Color32(106, 106, 106, 160);
        int cur_score = GameManager.score + 50* GameManager.stars;
        if(cur_score> PlayerPrefs.GetInt("highScore"+ GameManager.level, 0)){
            PlayerPrefs.SetInt("highScore"+ GameManager.level, cur_score);
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
        if(star >= 3f){
            star1.color = color;
            star2.color = color;
            star3.color = color; 
        }
        Debug.Log(star);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float calculateStar(){
        int l = getMinLives(GameManager.level);
        float lives = GameManager.lives/(10.0f-l);
        float score = GameManager.score/ (highScore *1.0f);
        float starPoint =1.0f;
        if(getStars(GameManager.level)!=0){
            starPoint = GameManager.stars / getStars(GameManager.level);
        }
        
        return (float) Math.Round((double)(2*lives + 2*score + starPoint) * 3 / 5, 2);

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
        levelMinLivesMapping[21] = 1;
        levelMinLivesMapping[22] = 1;
        levelMinLivesMapping[28] = 3;
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
        levelMinLivesMapping[45] = 3;
        levelMinLivesMapping[41] = 3;
        levelMinLivesMapping[42] = 2;

    }
    private void mapStars() {
        levelStarsMapping[1] = 0;
        levelStarsMapping[2] = 0;
        levelStarsMapping[3] = 0;
        levelStarsMapping[4] = 2;
        levelStarsMapping[5] = 2;
        levelStarsMapping[6] = 2;
        levelStarsMapping[7] = 2;
        levelStarsMapping[20] = 2;
        levelStarsMapping[21] = 2;
        levelStarsMapping[22] = 1;
        levelStarsMapping[28] = 0;
        levelStarsMapping[8] = 2;
        levelStarsMapping[9] = 2;
        levelStarsMapping[10] = 2;
        levelStarsMapping[16] = 2;
        levelStarsMapping[18] = 2;
        levelStarsMapping[19] = 2;
        levelStarsMapping[15] = 2;
        levelStarsMapping[11] = 2;
        levelStarsMapping[12] = 2;
        levelStarsMapping[13] = 2;
        levelStarsMapping[17] = 2;
        levelStarsMapping[35] = 2;
        levelStarsMapping[45] = 0;
        levelStarsMapping[41] = 2;
        levelStarsMapping[42] = 2;
    }
    public int getMinLives(int level){
        return levelMinLivesMapping[level];
    }
    public int getStars(int level){
        return levelStarsMapping[level];
    }
}

