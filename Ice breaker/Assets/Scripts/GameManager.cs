using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{  
    public static int score = 0;
    public int level = 1;
    public int lives = 3;
    private static GameManager _instance;
    // public TextMesh scoreText;

    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    private void Awake(){
        _instance = this;
       DontDestroyOnLoad(gameObject);

       SceneManager.sceneLoaded += OnLevelLoaded;
    } 
    private void Start() {
        NewGame(); 
        // scoreText.text = "Score: " + Scoring.totalScore;
		// Scoring.text = "Score: " + score;
    }

    private void Update() {
    }

    private void NewGame() {
        // this.score = 0;
        AnalyticsManager.instance.Send(0,1);
		score = 0;
        this.lives = 3;
        
        LoadLevel(1);
    }

    private void LoadLevel(int level) {
        this.level = level;
        SceneManager.LoadScene("Level" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode) {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }

    public void Hit(Brick brick) {
        //this.score += brick.points;
		score += brick.points;
        // scoreText.text = "Score: " + Scoring.totalScore;
		// Scoring.text = "Score: " + score;

        if (Cleared()) {
            AnalyticsManager.instance.Send(1, 1);
            LoadLevel(level + 1);
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
        // NewGame();
        AnalyticsManager.instance.Send(1, 0);
        SceneManager.LoadScene("GameOver");
    }

    public void Miss() {
        this.lives--;

        if(this.lives == 0){
           GameOver();
        } 
    }
}