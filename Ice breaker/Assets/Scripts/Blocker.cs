using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    
    private float rot_ang ;

    private void Start(){
        rot_ang = -6.0f * Time.deltaTime;
    }

    private void Update(){
        this.transform.Rotate(0, 0, rot_ang);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if(collision.gameObject.name == "Ball"){
            ball.ResetBall();
            FindObjectOfType<GameManager>().Miss();
            foreach (IPaddle paddle in GameManager.Instance.activePaddles) {
                paddle.ResetPaddle();
            }

            AnalyticsManager.instance.death_by_blocker(GameManager.level);
        }
    }
}
