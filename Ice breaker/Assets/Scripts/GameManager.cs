using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public int score = 0;
    public int level = 1;
    public int lives = 3;
    private string activePaddle = "Paddle";
    private static GameManager _instance;

    private void Awake(){
        _instance = this;
       DontDestroyOnLoad(gameObject);
    } 
    private void Start() {
        NewGame();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.W)) {
            this.activePaddle = "TopPaddle";
        } else if (Input.GetKey(KeyCode.D)) {
            this.activePaddle = "RightPaddle";
        } else if (Input.GetKey(KeyCode.A)){
            this.activePaddle = "LeftPaddle";
        } else if (Input.GetKey(KeyCode.S)){
            this.activePaddle = "Paddle";
        }
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

    public string GetActivePaddle() {
        return this.activePaddle;
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
}