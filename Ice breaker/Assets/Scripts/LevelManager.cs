using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    public static float timeLeft;

    public static DateTime starttime;
    public Button[] buttons;
    private Color32 color;

    public static Dictionary < string, int > levelMapping = new Dictionary < string, int > ();
    
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
        // for(int i=0;i<buttons.Length; i++){
        //     buttons[i].interactable = true;
        // }
        
        levelMapping["Easy1"]=1;
        levelMapping["Easy2"]=2;
        levelMapping["Easy3"]=3;
        levelMapping["Easy4"]=4;
        levelMapping["Easy5"]=5;
        levelMapping["Easy6"]=6;
        levelMapping["Easy7"]=7;
        levelMapping["Easy8"]=20;
        levelMapping["Medium1"]=8;
        levelMapping["Medium2"]=9;
        levelMapping["Medium3"]=10;
        levelMapping["Medium4"]=16;
        levelMapping["Medium5"]=18;
        levelMapping["Medium6"]=19;
        levelMapping["Medium7"]=15;
        levelMapping["Hard1"]=11;
        levelMapping["Hard2"]=12;
        levelMapping["Hard3"]=13;
        levelMapping["Hard4"]=17;
        levelMapping["Dynamic1"]=35;
       
    }

    public void LoadLevel(int levelInd){
        GameManager.level = levelInd;
        GameManager.lives = 10;
        // AnalyticsManager.instance.Send2(levelInd);
        SceneManager.LoadScene("Level" + levelInd);
    }

    public int MaxLevelPerCategory(string category){
        int max_level=-1;
        foreach(var entry in levelMapping)
        {
            if(getCategory(entry.Key) == category){
                max_level = Math.Max(getCategoryLevel(entry.Key), max_level);
            }
        }
        return max_level;
    }

    public string getCategory(string level){
        string b = string.Empty;
        for (int i=0; i< level.Length; i++)
        {
            if (Char.IsDigit(level[i]))
            {
                return b;
            }
            b += level[i];
        }
        return b;
    }

    public int getCategoryLevel(string level){
        string b = string.Empty;
        for (int i=0; i< level.Length; i++)
        {
            if (Char.IsDigit(level[i]))
            {
                b += level[i];
            }
            
        }
        return int.Parse(b);
    }

    public int GetNextLevel(int level){
        string current_level=""; 
        foreach(var entry in levelMapping)
        {
            if(entry.Value == level){
                current_level = entry.Key;
                break;
            }
        }

        string cat = getCategory(current_level);
        int max_cat_levels = MaxLevelPerCategory(cat);
        int catLevel = getCategoryLevel(current_level);
        string nextLevel;

        Debug.Log(cat);
        if(catLevel == max_cat_levels){
            if(cat == "Easy"){
                nextLevel = "Medium1";
            }
            else if(cat == "Medium"){
                nextLevel = "Hard1";
            }
            else{
                nextLevel = "Easy1";
            }
        }
        else{
            nextLevel = cat+Convert.ToString(catLevel+1);
        }

        return levelMapping[nextLevel];
    }

    public void LoadTutorialLevel(int levelInd) 
	{
        timeLeft = 20f;
        starttime = DateTime.Now;
        GameManager.level = levelInd;
        GameManager.lives = 10;
        //AnalyticsManager.instance.Send2(levelInd);
        SceneManager.LoadScene("T" + levelInd);
    }

    public void LoadTutorialLevelFromWinScreen(string levelInd) 
	{
        timeLeft = 20f;
        starttime = DateTime.Now;
        int lvl = levelMapping[levelInd];
        GameManager.level = lvl;
        GameManager.lives = 10;
        //AnalyticsManager.instance.Send2(levelInd);
        SceneManager.LoadScene("T" + lvl);
    }

    public void LoadEasyLevels(){
        SceneManager.LoadScene("EasyLevels");
    }

    public void LoadMediumLevels(){
        SceneManager.LoadScene("MediumLevels");
    }

    public void LoadHardLevels(){
        SceneManager.LoadScene("HardLevels");
    }
    
    public void LoadDynamicLevels(){
        SceneManager.LoadScene("DynamicLevels");
    }

    public void LoadHome(){
        SceneManager.LoadScene("Home");
    }

    public void LoadLevels(){
        int currLevel = GameManager.level;
        string strLevel = "";
        foreach(var entry in levelMapping) {
            if(entry.Value == currLevel){
                strLevel = entry.Key;
                break;
            }
        }
        string levelType = getCategory(strLevel);
        if(levelType == "Easy"){
            SceneManager.LoadScene("EasyLevels");
        } else if(levelType == "Medium") {
            SceneManager.LoadScene("MediumLevels");
        } else if(levelType == "Hard"){
            SceneManager.LoadScene("HardLevels");
        }
        else if(levelType == "Dynamic"){
            SceneManager.LoadScene("DynamicLevels");
        }
    }

    public void LoadLevelStars(string level) {
        GameObject imageObject = GameObject.FindGameObjectWithTag("star1");
        GameObject imageObject2 = GameObject.FindGameObjectWithTag("star2");
        GameObject imageObject3 = GameObject.FindGameObjectWithTag("star3");
 
        if(imageObject != null && imageObject2 != null && imageObject3 != null){
            Image star1 = imageObject.GetComponent<Image>();
            Image star2 = imageObject2.GetComponent<Image>();
            Image star3 = imageObject3.GetComponent<Image>();

            float star = GameManager.LevelStarMapping[levelMapping[level]];
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


    // Update is called once per frame
    void Update()
    {
        
    }
}