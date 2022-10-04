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
        SceneManager.LoadScene("Level" + levelInd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
