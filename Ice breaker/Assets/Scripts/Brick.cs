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
    
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (!this.unbreakable) {
            this.health = this.states.Length;
            // spriteRenderer.sprite = this.states[this.health - 1];
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

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.name == "Ball" )
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if(!(this.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color))
            {
                return;
            }

            Vector3 position = ball.gameObject.transform.position;
            Vector3 velocity = ball.rigidbody.velocity;
            Debug.Log(position);
            Debug.Log(velocity);

            Color brick_color = this.GetComponent<SpriteRenderer>().color;
            Color power_brick_color = new Color(243.0f/255.0f, 38f/255.0f, 38f/255.0f, 255f/255.0f);

			Debug.Log(brick_color);

            if (ball.GetComponent<SpriteRenderer>().color == brick_color)
            {
                Hit();
            }
            if (this.GetComponent<SpriteRenderer>().color == power_brick_color)
            {
				this.brickPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Debug.Log("Power brick hit!");
                this.points=300;	
               // ball.setTimer();	
				Hit();
				Instantiate(Capsule, this.brickPosition, Quaternion.identity);
            }
            ball.gameObject.transform.position = position;
            ball.rigidbody.velocity = velocity;   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.name == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if((this.GetComponent<SpriteRenderer>().color == ball.GetComponent<SpriteRenderer>().color))
            {
                return;
            }
            Vector3 position = ball.gameObject.transform.position;
            Vector3 velocity = ball.rigidbody.velocity;
            Debug.Log(position);
            Debug.Log(velocity);

            Color brick_color = this.GetComponent<SpriteRenderer>().color;
            Color power_brick_color = new Color(243.0f/255.0f, 38f/255.0f, 38f/255.0f, 255f/255.0f);

			Debug.Log(brick_color);

            if (ball.GetComponent<SpriteRenderer>().color == brick_color)
            {
                Hit();
            }
            if (this.GetComponent<SpriteRenderer>().color == power_brick_color)
            {
				this.brickPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                Debug.Log("Power brick hit!");
                this.points=300;	
                ball.setTimer();	
				Hit();
				Instantiate(Capsule, this.brickPosition, Quaternion.identity);
            }
            ball.gameObject.transform.position = position;
            ball.rigidbody.velocity = velocity;   
        }
    }
}