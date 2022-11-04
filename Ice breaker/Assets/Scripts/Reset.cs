using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        levelManager.LoadTutorialLevel(GameManager.level);
    }
    
    public void Home()
    {
        GameManager.lives = 10;
        GameManager.score = 0;

        AnalyticsManager.instance.process_analytics_one();
        AnalyticsManager.instance.process_analytics_five();
        AnalyticsManager.instance.process_analytics_six();
        SceneManager.LoadScene("Levels");
    }

    public void ResetLevel()
    {
        GameManager.lives = 10;
        GameManager.score = 0;
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadTutorialLevel(GameManager.level);
        // SceneManager.LoadScene("Level"+ GameManager.level);
    }
    public void ResetTutorialLevel() {
        GameManager.lives = 10;
        GameManager.score = 0;
        
        AnalyticsManager.instance.process_analytics_one();
        AnalyticsManager.instance.process_analytics_five();
        AnalyticsManager.instance.process_analytics_six();
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadTutorialLevel(GameManager.level);
        // SceneManager.LoadScene("T"+ GameManager.level);
    }

    public void NextLevel() {
        GameManager.lives = 10;
        GameManager.score = 0;
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadTutorialLevel(GameManager.level + 1);
    }
}
