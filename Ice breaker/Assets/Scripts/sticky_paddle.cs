using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticky_paddle : MonoBehaviour
{

    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && ball != null)
        {
            if(ball.rigidbody.velocity.magnitude == 0){
                float y_diff = transform.position.y - ball.gameObject.transform.position.y;
                float x_diff = - transform.position.x + ball.gameObject.transform.position.x;
                Vector3 temp = new Vector3(x_diff, y_diff ,0.0f);
                ball.gameObject.transform.position = transform.position + temp;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            ball.rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }

        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("coin landed");
            GameManager.score += 200;
        }
    }
}
