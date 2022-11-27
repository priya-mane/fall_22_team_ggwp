using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image star1;
    public Image star2;
    public Image star3;
    public string level;
    private Color32 color;
    public static LevelManager levelManager;
    void Start()
    {   
        LoadLevelStars(LevelManager.levelMapping[level]);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void LoadLevelStars(int level) {
        float star;
        if(GameManager.LevelStarMapping.ContainsKey(level)){
            star = GameManager.LevelStarMapping[level];
        } else {
            star = 0f;
            GameManager.LevelStarMapping[level] = 0f;
        }
        color = new Color32(233, 225, 43, 255);
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
}
