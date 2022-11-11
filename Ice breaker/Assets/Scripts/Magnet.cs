using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Magnet : MonoBehaviour
{

  public float magnetForce = 100;
  public bool shouldRepel = false;
  public bool shouldOscillate = false;
  private Transform circle;
  private CircleCollider2D collider;
  private Vector3 delta=new Vector3(-0.03f, -0.03f, 0.0f);
  private float colliderDelta = -0.03f;
  private Vector3 initialScale;
  List<Rigidbody2D> caughtRigidbodies = new List<Rigidbody2D>();

  void Start()
  {
    this.circle = this.gameObject.transform.GetChild(0);
    this.initialScale = this.circle.localScale;
    this.collider = gameObject.GetComponent<CircleCollider2D>();
  }
  void Update()
  {
    if(this.shouldOscillate) {
      oscillateMagneticForce();
    }
  }
  void FixedUpdate()
  {
    for (int i = 0; i < caughtRigidbodies.Count; i++)
    {
      caughtRigidbodies[i].velocity = (transform.position - (caughtRigidbodies[i].transform.position)) * magnetForce * Time.deltaTime;
    }
  }

  void oscillateMagneticForce(){
    Vector3 objectScale = circle.transform.localScale;
    if((delta.x < 0 && objectScale.x <= 0 ) || (delta.x > 0 && objectScale.x >= this.initialScale.x))
    {
      delta = -delta;
      colliderDelta = -colliderDelta;
    }
    circle.localScale += delta;
    collider.radius += colliderDelta;
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.GetComponent<Rigidbody2D>())
    {
      Rigidbody2D r = other.GetComponent<Rigidbody2D>();
      float effect = shouldRepel ? -1*magnetForce : 1*magnetForce;
      r.velocity = (transform.position - r.transform.position)*effect*Time.deltaTime;
    }
  }
}
