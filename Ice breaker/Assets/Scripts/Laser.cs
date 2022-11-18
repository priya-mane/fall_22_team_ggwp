using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(collision.gameObject.name == "Ball" && 
        !Common.IsSameColor(GetComponent<SpriteRenderer>().color, 
        collision.gameObject.GetComponent<SpriteRenderer>().color)){
            ball.ResetBall();
            FindObjectOfType<GameManager>().Miss();
            foreach (IPaddle paddle in GameManager.Instance.activePaddles) {
                paddle.ResetPaddle();
            }

            // AnalyticsManager.instance.death_by_blocker(GameManager.level);
        }
    }
}
