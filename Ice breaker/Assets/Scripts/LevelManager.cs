using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;

    public Button[] buttons;
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
        for(int i=0;i<buttons.Length; i++){
            buttons[i].interactable = true;
        }
        
    }

    public void LoadLevel(int levelInd){
        GameManager.level = levelInd;
        GameManager.lives = 5;
        AnalyticsManager.instance.Send2(levelInd);
        SceneManager.LoadScene("Level" + levelInd);
    }

    public void LoadTutorialLevel(int levelInd) {
        GameManager.level = levelInd;
        GameManager.lives = 5;
        AnalyticsManager.instance.Send2(levelInd);
        SceneManager.LoadScene("T" + levelInd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
