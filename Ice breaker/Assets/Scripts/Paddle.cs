using UnityEngine;

public class Paddle : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    private float speed = 150f;
    public float maxBounceAngle = 75f;
    private Vector3 initialPosition;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        this.initialPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Update() {
        Color active_color = new Color(255.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f, 255f/255.0f);
        Color inactive_color = new Color(255.0f/255.0f, 255.0f/255.0f, 0f/255.0f, 90f/255.0f);
        
        if(gameObject.tag == GameManager.Instance.GetActivePaddle())
        {
            // change color to white
            this.GetComponent<SpriteRenderer>().color = active_color;
        }
        else
        {
            // change color to yellow
            this.GetComponent<SpriteRenderer>().color = inactive_color;
        }

        if(gameObject.tag == GameManager.Instance.GetActivePaddle()) {
            if(gameObject.tag == "Paddle" || gameObject.tag == "TopPaddle") {
                if (Input.GetKey(KeyCode.LeftArrow)) {
                    this.direction = Vector2.left;
                } else if (Input.GetKey(KeyCode.RightArrow)) {
                    this.direction = Vector2.right;
                } else {
                    this.direction = Vector2.zero;
                }
            }else {
                if (Input.GetKey(KeyCode.UpArrow)) {
                    this.direction = Vector2.up;
                } else if (Input.GetKey(KeyCode.DownArrow)) {
                    this.direction = Vector2.down;
                } else {
                    this.direction = Vector2.zero;
                }
            }
        }
    }

    private void FixedUpdate() {
        if (this.direction != Vector2.zero) {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

            Color black_color = new Color(0f, 0f, 0f, 1f);
            Color white_color = new Color(1f, 1f, 1f, 1f);

            if (ball.GetComponent<SpriteRenderer>().color == black_color)
            {
                ball.GetComponent<SpriteRenderer>().color = white_color; 
            }
            else
            {
                ball.GetComponent<SpriteRenderer>().color = black_color;
            }
        }
    }

    public void ResetPaddle() {
        gameObject.transform.position = initialPosition;
    }

}