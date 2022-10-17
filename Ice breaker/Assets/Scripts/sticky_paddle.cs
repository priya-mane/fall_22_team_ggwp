using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticky_paddle : MonoBehaviour
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
            Vector2 paddlePosition = transform.position;
            ball.rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
