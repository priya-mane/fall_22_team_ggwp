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
    private bool timerIsRunning = false;
    private int color = 1;
    public bool isTimerOn;
    private Color red_color;
	 private Color blue_color;
    private Color yellow_color;
    
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (!this.unbreakable) {
            this.health = this.states.Length;
            // spriteRenderer.sprite = this.states[this.health - 1];
        }
        if(isTimerOn){
            red_color = new Color(149f/255f,73f/255f,62f/255f,1);
            blue_color = new Color(60f/255f,75f/255f,161f/255f,1);
            yellow_color = new Color(178f/255f,150f/255f,53f/255f,1);
            timerIsRunning = true;
            if(color ==1){
                timeRemaining = 10;
            }
            else if(color == 2){
                timeRemaining = 30;
            }
            else{
                timerIsRunning = false;
            }
        }
         Debug.Log(color + " start");
    }
    void Update()
    {
        if (timerIsRunning && isTimerOn)
        {
            // Debug.Log(color+ " "+timeRemaining + " update");
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if(color == 1){
                    Debug.Log("Blue" + timeRemaining.ToString());
                    this.GetComponent<SpriteRenderer>().color = blue_color;
                    timeRemaining = 20;
                    color +=1;
                }
                else if(color == 2){
                    Debug.Log("Yellow" + timeRemaining.ToString());
                    this.GetComponent<SpriteRenderer>().color = yellow_color;
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
			var c1 = ball.GetComponent<SpriteRenderer>().color; 
			var c2= brick_color;

			Debug.Log(c1);
			Debug.Log(c2);
            if ((Color)(Color32)c1 == (Color)(Color32)c2)
            {
                Hit();
            }
            if (this.GetComponent<SpriteRenderer>().color == power_brick_color)
            {
				this.brickPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                //Debug.Log("Power brick hit!");
                this.points=300;				
				Hit();
				//Instantiate(Capsule, this.brickPosition, Quaternion.identity);
            }

        }
    }
}