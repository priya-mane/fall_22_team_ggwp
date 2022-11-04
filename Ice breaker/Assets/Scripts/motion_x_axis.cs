using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion_x_axis : MonoBehaviour
{
    public float speed = 0.1f;
	public Rigidbody body;
	public Vector3 startPos ;
	private Vector3 endPos;
	public float oscillation_distance = 3f;
    // Start is called before the first frame update
    void Start()
    {
		startPos =  new Vector3(this.transform.position.x - oscillation_distance,this.transform.position.y, this.transform.position.z);
		this.transform.position = startPos;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.right*speed;
		endPos =  new Vector3(this.transform.position.x + oscillation_distance,this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
		/*
        // this.gameObject.transform.position += Vector3.right*speed;
		Vector3 pos = transform.position;
    	float length = 1.0f; // Desired length of the ping-pong
    	float bottomFloor = 1.5f; // The low position of the ping-pong
    	pos.y = Mathf.PingPong(Time.time,  length) + bottomFloor;
    	transform.position = pos; // new position
		*/
		//this.transform.position += new Vector3(this.transform.position.x + Mathf.PingPong(Time.time * speed, length), this.transform.position.y, this.transform.position.z);

    }

	void FixedUpdate() 
	{
		Vector3 currentPos = this.transform.position;
		if ((currentPos.x >= endPos.x && this.GetComponent<Rigidbody2D>().velocity.x > 0) || (currentPos.x <= startPos.x  && this.GetComponent<Rigidbody2D>().velocity.x < 0))
		{
			this.GetComponent<Rigidbody2D>().velocity = -1.0f * this.GetComponent<Rigidbody2D>().velocity;
		}        
  }
}
