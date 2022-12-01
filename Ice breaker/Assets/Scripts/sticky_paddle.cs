using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticky_paddle : MonoBehaviour
{

    private Ball ball;
    private GameObject progressBar;
    public bool hasTimer = false;
    private bool startTimer = false;
    public float totalTime = 4.0f;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        if(hasTimer) 
        {
            progressBar = gameObject.transform.GetChild(0).gameObject;
        }
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
        if (hasTimer && startTimer) {
            if(currentTime > 0) {
                this.currentTime -= Time.deltaTime;
                Vector3 pLocalScale = progressBar.transform.localScale;
                pLocalScale.x = this.currentTime/this.totalTime;
                progressBar.transform.localScale = pLocalScale;
            }else {
                startTimer = false;
                if(ball != null && ball.rigidbody.velocity.magnitude == 0) {
                    ball.ResetBall();
                }
                progressBar.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void StartTimer(){
        this.startTimer = true;
        this.currentTime = this.totalTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            ball.rigidbody.velocity = new Vector3(0f, 0f, 0f);
            if(hasTimer) {
                StartTimer();
            }
        }

        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("coin landed");
            GameManager.score += 75;
        }
    }
}
