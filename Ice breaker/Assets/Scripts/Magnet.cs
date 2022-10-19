using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Magnet : MonoBehaviour
{

  public float magnetForce = 100;
  public bool shouldRepel = false;
  List<Rigidbody2D> caughtRigidbodies = new List<Rigidbody2D>();

  void Start()
  {
    
  }

  void FixedUpdate()
  {
    for (int i = 0; i < caughtRigidbodies.Count; i++)
    {
      caughtRigidbodies[i].velocity = (transform.position - (caughtRigidbodies[i].transform.position)) * magnetForce * Time.deltaTime;
    }
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
