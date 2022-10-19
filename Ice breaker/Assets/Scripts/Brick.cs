using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health { get; private set; }
    public Sprite[] states = new Sprite[0];
    public bool unbreakable;
	private Vector3 brickPosition;
	public GameObject Capsule;
    public int points = 100;
    private float timeRemaining;
    private float timeprev;
    public bool timerIsRunning = false;
    public int color;
    public TimeBar timeBar;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (!this.unbreakable) {
            this.health = this.states.Length;
            // spriteRenderer.sprite = this.states[this.health - 1];
        }
        timerIsRunning = true;
        //timeBar.SetMaxTime(100);
        if(color ==1){
            timeRemaining = 10;
            timeprev = 10;
        }
        else if(color == 2){
            timeRemaining = 30;
            timeprev = 30;
            
        }
        else{
            timerIsRunning = false;
        }
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if(color == 1){
                    // Debug.Log("Blue" + timeRemaining.ToString());
                    this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f,255.0f, 1);
                    timeRemaining = 20;
                    timeprev = 20;
                    color +=1;
                }
                else if(color == 2){
                    // Debug.Log("Yellow" + timeRemaining.ToString());
                    this.GetComponent<SpriteRenderer>().color = new Color(255.0f, 255.0f,0.0f, 1);
                    timerIsRunning = false;
                    color +=1;
                }
            }
        }
    }

    private void Hit() {
        if (this.unbreakable) { return; }
        
        this.health--;

        if (health <= 0) {
            gameObject.SetActive(false);
        } else {
            spriteRenderer.sprite = states[health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            Color brick_color = this.GetComponent<SpriteRenderer>().color;
            Color power_brick_color = new Color(243.0f/255.0f, 38f/255.0f, 38f/255.0f, 255f/255.0f);

            if (ball.GetComponent<SpriteRenderer>().color == brick_color)
            {
                Hit();
            }
            if (this.GetComponent<SpriteRenderer>().color == power_brick_color)
            {
				this.brickPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Debug.Log("Power brick hit!");
                this.points=300;				
				Hit();
				Instantiate(Capsule, this.brickPosition, Quaternion.identity);
            }

        }
    }
}