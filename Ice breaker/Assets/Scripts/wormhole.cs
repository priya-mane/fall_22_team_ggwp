using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormhole : MonoBehaviour
{
    private int outGoing;
    public string successorWormholeTagName;
    void Start()
    {
        outGoing = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(outGoing > 0){
            outGoing -= 1;
            return;
        }  

        wormhole succWormhole = GameObject.FindWithTag(successorWormholeTagName).gameObject.GetComponent<wormhole>();
        succWormhole.outGoing += 1;     

        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {   
            float newAngle = -1 * Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

            Color black_color = new Color(0f, 0f, 0f, 1f);
            Color white_color = new Color(1f, 1f, 1f, 1f);

            ball.transform.position = succWormhole.transform.position;

            if (ball.GetComponent<SpriteRenderer>().color == black_color) {
                ball.GetComponent<SpriteRenderer>().color = white_color; 
            }
            else {
                ball.GetComponent<SpriteRenderer>().color = black_color;
            }
        }

        Brick brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null)
        {
            brick.transform.position = succWormhole.transform.position;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(outGoing > 0){
            outGoing -= 1;
            return;
        }  

        wormhole succWormhole = GameObject.FindWithTag(successorWormholeTagName).gameObject.GetComponent<wormhole>();
        succWormhole.outGoing += 1;     

        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {   
            float newAngle = -1 * Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

            Color black_color = new Color(0f, 0f, 0f, 1f);
            Color white_color = new Color(1f, 1f, 1f, 1f);

            ball.transform.position = succWormhole.transform.position;

            if (ball.GetComponent<SpriteRenderer>().color == black_color) {
                ball.GetComponent<SpriteRenderer>().color = white_color; 
            }
            else {
                ball.GetComponent<SpriteRenderer>().color = black_color;
            }
        }

        Brick brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null)
        {
            brick.transform.position = succWormhole.transform.position;
        }
    
    }
}
