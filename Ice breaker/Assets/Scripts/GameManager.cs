using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{  
    public static int score = 0;
    public static int level = 1;
    public static int lives = 5;
    private static GameManager _instance;
    public static GameObject selectedObject;
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    public List<IPaddle> activePaddles;

    private void Awake(){
        _instance = this;
        activePaddles = new List<IPaddle>();
       DontDestroyOnLoad(gameObject);

       SceneManager.sceneLoaded += OnLevelLoaded;
    } 
    private void Start() {
        NewGame(); 
    }

    private void Update() {
    }

    private void NewGame() {
        // this.score = 0;
        if(level == 1){
            AnalyticsManager.instance.Send(0,1,0);
        }
        UnregisterPaddles();
		score = 0;
        lives = 5;
        //LoadLevel(9);
        SceneManager.LoadScene("Levels");
		//LoadLevel(2);
    }

    private void LoadLevel(int level) {
        UnregisterPaddles();
        GameManager.level = level;
        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode) {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }

    public void Hit(Brick brick) {
		score += brick.points;

        if (Cleared()) {
            AnalyticsManager.instance.Send(level, 1, lives);
            SceneManager.LoadScene("Levels");
        }
    }

    private bool Cleared() {
        for (int i = 0; i < bricks.Length; i++) {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable) {
                return false;
            }
        }

        return true;
    }

    private int NumerOfBrickCleared() {
        int num = 0;
        for (int i = 0; i < bricks.Length; i++) {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable) {
                num++;
            }
        }

        return num;
    }

    public void RegisterPaddles(IPaddle paddle) {
        activePaddles.Add(paddle);
    }

    public void UnregisterPaddles() {
        activePaddles = new List<IPaddle>();
    }

    public static GameManager Instance
    {
        get
        {
            if(_instance == null) {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }

    private void GameOver() {
        AnalyticsManager.instance.Send(level, 0, lives);
        // NewGame();
        UnregisterPaddles();

        int num = NumerOfBrickCleared();
        
        SceneManager.LoadScene("GameOver");
    }

    public void Miss() {
        lives--;

        if(lives == 0) {
            GameOver();
        } 
    }
}