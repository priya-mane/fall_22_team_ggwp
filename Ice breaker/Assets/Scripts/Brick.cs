using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health { get; private set; }
    public Sprite[] states = new Sprite[0];
    public bool unbreakable;
    
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
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            Color brick_color = this.GetComponent<SpriteRenderer>().color;

            Debug.Log(brick_color);

            if (ball.GetComponent<SpriteRenderer>().color == brick_color)
            {
                Hit();
            }
            
        }
    }
}