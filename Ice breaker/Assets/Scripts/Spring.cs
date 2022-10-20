using UnityEngine;
using System;
using System.Collections;

public class Spring : MonoBehaviour {
	public float maxBounceAngle = 60f;

	private void Start(){
		Debug.Log("Rotation: " + this.gameObject.transform.eulerAngles);
		Debug.Log("sin : " + Mathf.Sin(this.gameObject.transform.eulerAngles.z));
		Debug.Log("cos : " + Mathf.Cos(this.gameObject.transform.eulerAngles.z));
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

            // float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            // Quaternion newAngle = this.gameObject.transform.rotation;

            // Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
			Debug.Log(ball.rigidbody.velocity);
			Debug.Log("Rotation: " + this.gameObject.transform.eulerAngles);
			Debug.Log("sin : " + Mathf.Sin((3.14159265f / 180f) * this.gameObject.transform.eulerAngles.z));
			Debug.Log("cos : " + Mathf.Cos((3.14159265f / 180f) * this.gameObject.transform.eulerAngles.z));

			float magnitude = ball.rigidbody.velocity.magnitude;

			Debug.Log("z rotation:" + this.gameObject.transform.eulerAngles.z);
			float angle = (3.14159265f / 180f) * this.gameObject.transform.eulerAngles.z;
			ball.rigidbody.velocity = new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle), 0f)*magnitude;
			/*
            Color black_color = new Color(0f, 0f, 0f, 1f);
            Color white_color = new Color(1f, 1f, 1f, 1f);

            if (ball.GetComponent<SpriteRenderer>().color == black_color) {
                ball.GetComponent<SpriteRenderer>().color = white_color; 
            }
            else {
                ball.GetComponent<SpriteRenderer>().color = black_color;
            }
			*/
        }
    }

}