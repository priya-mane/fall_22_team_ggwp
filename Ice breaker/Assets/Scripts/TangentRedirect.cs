using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentRedirect : MonoBehaviour
{
  public float ballSpeed = 7.0f;

  public float GetPendulumBallSpeed()
  {
    return this.ballSpeed;
  }
  
  void Start()
  {
    // rigidBody = transform.parent.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.name == "Ball")
    {
      Ball ball = other.gameObject.GetComponent<Ball>();
      ball.setPendulum(this);
    }
  }
}