using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health { get; private set; }
    public Sprite[] states = new Sprite[0];
    public bool unbreakable;

    public int points = 100;
    
    // Color myColor = new Color(210f, 2f, 2f, 1f);

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (!this.unbreakable) {
            this.health = this.states.Length;
            spriteRenderer.sprite = this.states[this.health - 1];
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
            Color power_brick_color = new Color(0.953f, 0.149f, 0.149f, 1.000f);

            // Debug.Log("Collided****");
            Debug.Log("Brick color = "+brick_color);
            Debug.Log("const color = "+power_brick_color);
            Debug.Log(brick_color.Equals(power_brick_color));
            Debug.Log(brick_color == power_brick_color);

            if (ball.GetComponent<SpriteRenderer>().color == brick_color)
            {
                Debug.Log("brick break");
                Hit();
            }
            else if ((int)(brick_color.r * 1000) == (int)(power_brick_color.r * 1000))
            {
                Debug.Log("Power brick hit!");
            }
            
        }
    }
}