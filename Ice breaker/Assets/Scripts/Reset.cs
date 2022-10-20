using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
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
        SceneManager.LoadScene("Level"+GameManager.level);
    }
    
    public void Home()
    {
        GameManager.lives = 10;
        GameManager.score = 0;
        SceneManager.LoadScene("Levels");
    }

    public void ResetLevel()
    {
        GameManager.lives = 10;
        GameManager.score = 0;
        SceneManager.LoadScene("Level"+ GameManager.level);
    }
    public void ResetTutorialLevel() {
        GameManager.lives = 10;
        GameManager.score = 0;
        SceneManager.LoadScene("T"+ GameManager.level);
    }
}
