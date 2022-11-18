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

    public Dictionary < string, int > levelMapping = new Dictionary < string, int > ();
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
        levelMapping["Easy8"]=12;
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
    }

    public void LoadLevel(int levelInd){
        GameManager.level = levelInd;
        GameManager.lives = 10;
        // AnalyticsManager.instance.Send2(levelInd);
        SceneManager.LoadScene("Level" + levelInd);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
