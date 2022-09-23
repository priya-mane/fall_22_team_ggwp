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
            if((gameObject.tag == "TopWall" && GameManager.Instance.GetActivePaddle() == "TopPaddle") ||
                (gameObject.tag == "BottomWall" && GameManager.Instance.GetActivePaddle() == "Paddle") ||
                (gameObject.tag == "LeftWall" && GameManager.Instance.GetActivePaddle() == "LeftPaddle") ||
                (gameObject.tag == "RightWall" && GameManager.Instance.GetActivePaddle() == "RightPaddle")) {
                    Debug.Log("the ball should be reset");
                    ball.ResetBall();
                    List<GameObject> paddles = new List<GameObject> {
                        GameObject.FindWithTag("TopPaddle"),
                        GameObject.FindWithTag("Paddle"),
                        GameObject.FindWithTag("LeftPaddle"),
                        GameObject.FindWithTag("RightPaddle")
                    };
                    foreach (GameObject paddle in paddles) {
                        paddle.GetComponent<Paddle>().ResetPaddle();
                    }
                    FindObjectOfType<GameManager>().Miss();
            }
           
        }
    }
}
