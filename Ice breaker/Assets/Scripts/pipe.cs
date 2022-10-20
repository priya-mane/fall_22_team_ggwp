using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)  {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {   
            float magnitude = ball.rigidbody.velocity.magnitude;
            float angle = (3.14159265f / 180f) * this.gameObject.transform.eulerAngles.z;
			ball.rigidbody.velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f)*magnitude;
        }
    }
}
