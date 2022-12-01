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
    public int points = 100;
    private float timeRemaining;
    private bool timerIsRunning = false;
    private int color = 1;
    public bool isTimerOn;
	public bool isHealthBrick;
    private Color red_color;
	private Color blue_color;
    private Color yellow_color;
	public GameObject coinPrefab;

	public bool releaseCoin;
    
    private void Awake() 
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
		
    }

    private void Start() 
	{
		red_color = new Color(149f/255f,73f/255f,62f/255f,1);
        blue_color = new Color(60f/255f,75f/255f,161f/255f,1);
        yellow_color = new Color(178f/255f,150f/255f,53f/255f,1);

        if (!this.unbreakable) {
            this.health = this.states.Length;
            // spriteRenderer.sprite = this.states[this.health - 1];
        }
        if(isTimerOn)
		{
            
            timerIsRunning = true;
            if(color ==1)
			{
                timeRemaining = 20;
            }
            else if(color == 2)
			{
                timeRemaining = 40;
            }
            else{
                timerIsRunning = false;
            }
        }
         
    }
    void Update()
    {
        if (timerIsRunning && isTimerOn)
        {
            
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if(color == 1){
                    
                    this.GetComponent<SpriteRenderer>().color = blue_color;
                    timeRemaining = 20;
                    color +=1;
                }
                else if(color == 2){
                    
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
		
		Color brick_color = this.GetComponent<SpriteRenderer>().color;

        FindObjectOfType<GameManager>().Hit(this);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            Color brick_color = this.GetComponent<SpriteRenderer>().color;
            
			var c1 = ball.GetComponent<SpriteRenderer>().color; 
			var c2 = brick_color;
			
			if ((Color)(Color32)c1 == (Color)(Color32)c2 || (isHealthBrick==true))
            {
				
				if ((Color)(Color32)brick_color == (Color)(Color32)red_color)
				{	
					this.points = 300;
				}
				else if ( (Color)(Color32)brick_color == (Color)(Color32)blue_color)
				{	
					this.points = 200;
				}
				else
				{	
					if (isHealthBrick)
					{
						GameManager.lives += 1;
						this.points = 0;
					}
					else	
					{
						this.points = 100;
					}
					
				}

				if (coinPrefab != null || releaseCoin==true)
				{
					Instantiate(coinPrefab, this.gameObject.transform.position, Quaternion.identity);
				}


                Hit();
            }
            else{
                AnalyticsManager.instance.mishit_capture(GameManager.level);
            }
            

        }
    }
}