using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            
                ball.ResetBall();
                FindObjectOfType<GameManager>().Miss();
                List<GameObject> paddles = new List<GameObject> {
                    GameObject.FindWithTag("Bar"),
                    GameObject.FindWithTag("Paddle"),
                    // GameObject.FindWithTag("LeftPaddle"),
                    // GameObject.FindWithTag("RightPaddle")
                };
                foreach (GameObject paddle in paddles) {
                    paddle.GetComponent<Paddle>().ResetPaddle();
                }
            
        }
    }
}
