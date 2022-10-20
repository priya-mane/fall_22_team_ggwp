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
	

    private void Awake()
{
        _instance = this;
        activePaddles = new List<IPaddle>();
       DontDestroyOnLoad(gameObject);
		/*
		red_color = new Color(149f/255f,73f/255f,62f/255f,1);
		blue_color = new Color(149f/255f,73f/255f,62f/255f,1);
		yellow_color = new Color(149f/255f,73f/255f,62f/255f,1);
		*/

       SceneManager.sceneLoaded += OnLevelLoaded;
    } 
    private void Start() {
        NewGame(); 
    }

    private void Update() {
    }
    public void SetBallColor(Color color){
        ball.SetColor(color);
    }
    private void NewGame() {
        // this.score = 0;
        if(level == 1){
            AnalyticsManager.instance.Send(0,1,0);
        }
        UnregisterPaddles();
		score = 0;
        lives = 5;
        
        SceneManager.LoadScene("Levels");
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

    public int[] NumerOfBrickCleared() {
        int[] num = new int[3];

        for (int i = 0; i < bricks.Length; i++) {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable) {
                if(bricks[i].gameObject.GetComponent<SpriteRenderer>().color == new Color(1f,0f,0f,1)){
                    num[0]+=1;
                }
                else if(bricks[i].gameObject.GetComponent<SpriteRenderer>().color == new Color(0f,0f,1f,1)){
                    num[1]+=1;
                }else{
                    num[2]+=1;
                }
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

        int num = SumArray(NumerOfBrickCleared());
        
        SceneManager.LoadScene("GameOver");
    }

    public void Miss() {
        lives--;

        if(lives == 0) {
            GameOver();
        } 
    }
    private int SumArray(int[] toBeSummed)
 {
     int sum = 0;
     foreach (int item in toBeSummed)
     {
         sum += item;
     }
     return sum;
 }
}