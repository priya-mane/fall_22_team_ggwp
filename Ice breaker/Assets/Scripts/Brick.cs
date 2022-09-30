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
            Color power_brick_color = new Color(243.0f/255.0f, 38f/255.0f, 38f/255.0f, 255f/255.0f);

            // Debug.Log("Collided****");
            Debug.Log("Brick color = "+brick_color);
            Debug.Log("const color = "+power_brick_color);
            Debug.Log("brick material color = " + this.GetComponent<SpriteRenderer>().material.color);

            if (ball.GetComponent<SpriteRenderer>().color == brick_color)
            {
                Debug.Log("brick break");
                Hit();
            }
            else if (this.GetComponent<SpriteRenderer>().color == power_brick_color)
            {
                Debug.Log("Power brick hit!");
            }
            
        }
    }
}