using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
                ball.ResetBall();
                FindObjectOfType<GameManager>().Miss();
                foreach (IPaddle paddle in GameManager.Instance.activePaddles) 
                {
                    paddle.ResetPaddle();
                }
        }
		

    }
}
