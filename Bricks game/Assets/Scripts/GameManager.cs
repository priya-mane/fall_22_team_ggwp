using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public int score = 0;
    public int level = 1;
    public int lives = 3;
    private void Awake(){
       DontDestroyOnLoad(gameObject);
    } 
    private void Start() {
        NewGame();
    }

    private void NewGame() {
        this.score = 0;
        this.lives = 3;
        
        LoadLevel(1);
    }

    private void LoadLevel(int level) {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }
}
