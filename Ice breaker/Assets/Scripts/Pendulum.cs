using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
  Rigidbody2D rigidBody;

  public float moveSpeed=20;
  public float leftAngle;
  public float rightAngle;

  public bool movingClockwise = true;
  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
  }
  
  public void ChangeMoveDir()
  {
    if (transform.rotation.z > rightAngle)
    {
      movingClockwise = false;
    }
    if (transform.rotation.z < leftAngle)
    {
      movingClockwise = true;
    }

  }

  public void Move()
  {
    ChangeMoveDir();

    if (movingClockwise)
    {
      rigidBody.angularVelocity = moveSpeed;
    }

    if (!movingClockwise)
    {
      rigidBody.angularVelocity = -1*moveSpeed;
    }
  }
}