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

    public void ResetLevel()
    {
        GameManager.lives = 5;
        GameManager.score = 0;
        SceneManager.LoadScene("Level"+GameManager.level);
    }
}
