using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(collision.gameObject.name == "Ball"){
            ball.ResetBall();
            FindObjectOfType<GameManager>().Miss();
        }
    }
}
