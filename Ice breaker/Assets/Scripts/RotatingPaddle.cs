using UnityEngine;

public class RotatingPaddle : MonoBehaviour, IPaddle
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    private float speed = 20f;
    public float maxBounceAngle = 60f;
    private Vector3 initialPosition;
    public float zAngle = -90.0f;
    private Quaternion initialRotation;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        this.initialPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        this.initialRotation = gameObject.transform.rotation;
        GameManager.Instance.RegisterPaddles(this);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            this.direction = Vector2.right;
        } else {
            this.direction = Vector2.zero;
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
            ball.setRotatingPaddle(this);
        }
    }

    public void ResetPaddle() {
        // gameObject.transform.position = initialPosition;
        this.gameObject.transform.rotation = this.initialRotation;
    }

    public void Rotate() {
      this.gameObject.transform.Rotate(0.0f, 0.0f, zAngle);
    }

    public Vector3 RedirectBall(Vector3 ballPosition) {
      Vector3 direction = (ballPosition - this.initialPosition).normalized;
      direction = Quaternion.AngleAxis(-zAngle, Vector3.forward) * direction;
      return direction;
    }

}