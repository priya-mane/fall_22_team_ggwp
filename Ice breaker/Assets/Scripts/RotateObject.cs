using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour
{
     private Camera myCam;
     private Vector3 screenPos;
     private float angleOffset;
    public float maxBounceAngle = 60f;
     void Start () {
         myCam=Camera.main;
     }
    private void OnMouseDown()
    {
        // Debug.Log(this.gameObject.name);
        GameManager.selectedObject = this.gameObject;
              
    }
     void Update () { 

        if (GameManager.selectedObject == this.gameObject){
            if (Input.GetKey(KeyCode.RightArrow)){
        transform.Rotate(0,0, 20 * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0,0, -20 * Time.deltaTime);
        }
        
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
            ball.rigidbody.velocity = ball.rigidbody.velocity*1.05f;

            Color black_color = new Color(0f, 0f, 0f, 1f);
            Color white_color = new Color(1f, 1f, 1f, 1f);

            if (ball.GetComponent<SpriteRenderer>().color == black_color) {
                ball.GetComponent<SpriteRenderer>().color = white_color; 
            }
            else
            {
                ball.GetComponent<SpriteRenderer>().color = black_color;
            }
        }
    }
}
