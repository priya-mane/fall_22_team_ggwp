using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{  
    public int score = 0;
    public int level = 1;
    public int lives = 3;

    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    private void Awake(){
       DontDestroyOnLoad(gameObject);

       SceneManager.sceneLoaded += OnLevelLoaded;
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

        // if(level > 1){
        //     SceneManager.LoadScene("GameOver");
        // }

        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode) {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }

    public void Hit(Brick brick) {
        this.score += brick.points;

        if (Cleared()) {
            LoadLevel(level + 1);
        }
    }

    public string Score() {
        return this.score.ToString();
    }

    private bool Cleared() {
        for (int i = 0; i < bricks.Length; i++) {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable) {
                return false;
            }
        }

        return true;
    }

    private void ResetLevel() {
        ball.ResetBall();
        paddle.ResetPaddle();
    }

    private void GameOver() {
        // NewGame();
        SceneManager.LoadScene("GameOver");
    }

    public void Miss() {
        this.lives--;

        if(this.lives > 0){
            ResetLevel();
        } else {
            GameOver();
        }
    }
}