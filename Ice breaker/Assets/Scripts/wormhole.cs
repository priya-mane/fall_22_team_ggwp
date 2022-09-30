using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormhole : MonoBehaviour
{
    private float wormholeCooldownTime = 0.5f;
    static private float nextCollisionMinTime;
    void Start()
    {
        nextCollisionMinTime = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(Time.time);
        if(Time.time > nextCollisionMinTime){
            Ball ball = collision.gameObject.GetComponent<Ball>();
            GameObject otherWormhole;

            if(gameObject.tag == "leftWormhole"){
                otherWormhole = GameObject.FindWithTag("rightWormhole");
            }
            else{
                otherWormhole = GameObject.FindWithTag("leftWormhole");
            }

            if (ball != null)
            {   

                float newAngle = -1 * Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);

                Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

                Color black_color = new Color(0f, 0f, 0f, 1f);
                Color white_color = new Color(1f, 1f, 1f, 1f);

                ball.transform.position = otherWormhole.transform.position;

                if (ball.GetComponent<SpriteRenderer>().color == black_color)
                {
                    ball.GetComponent<SpriteRenderer>().color = white_color; 
                }
                else
                {
                    ball.GetComponent<SpriteRenderer>().color = black_color;
                }
                nextCollisionMinTime = Time.time + wormholeCooldownTime;
            }
        }
    }
}
