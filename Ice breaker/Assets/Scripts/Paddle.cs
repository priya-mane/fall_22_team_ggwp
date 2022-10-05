using UnityEngine;

public class Paddle : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    private float speed = 20f;
    public float maxBounceAngle = 60f;
    private Vector3 initialPosition;
    public float jumpAmount = 10;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        this.initialPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            this.direction = Vector2.right;
        } else {
            this.direction = Vector2.zero;
        }

         if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }

    private float GetRandomNumber(float minimum, float maximum) { 
        System.Random random = new System.Random();
        return (float)(random.NextDouble() * (maximum - minimum) + minimum);
    }
    private void FixedUpdate() {
        if((gameObject.tag == "Paddle" || gameObject.tag == "TopPaddle") && this.direction != Vector2.zero) {
            this.transform.Translate(this.direction * this.speed*Time.deltaTime);
        }
        if(gameObject.tag == "LeftPaddle" || gameObject.tag == "RightPaddle") {
            Vector3 pointA = new Vector3(this.initialPosition.x, -7, 0);
            Vector3 pointB = new Vector3(this.initialPosition.x, 7, 0);
            float factor = GetRandomNumber(1.1f, 1.2f);
            transform.position= Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time / speed, 1f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;


            // This is to reflect the ball

            // float offset = paddlePosition.x - contactPoint.x;
            // float maxOffset = collision.otherCollider.bounds.size.x / 2;

            // float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            // float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            // float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            // Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            // ball.rigidbody.velocity = ball.rigidbody.velocity*1.05f;

            // ----------------------


            ball.setPaddle(this.gameObject);

            ball.gameObject.transform.position = this.gameObject.transform.position;
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