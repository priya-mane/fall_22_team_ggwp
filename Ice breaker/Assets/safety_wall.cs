using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safety_wall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject top_wall;
    public GameObject right_wall;
    public GameObject bottom_wall;
    public GameObject left_wall;
    public GameObject ball;
    
    void Start()
    {
        
    }

	bool ballAtStart()
	{
		if(ball.gameObject.transform.position.x == -0.15f && ball.gameObject.transform.position.y==-3.75f )
		{
			return true;
		}
		else
		{
			return false;
		}
	}

    // Update is called once per frame
    void Update()
    {
		// 
        if (ball.GetComponent<Rigidbody2D>().velocity.magnitude!=0 || ballAtStart())
        {
            if (Input.GetKey("w"))
            {
                top_wall.SetActive(true);
                bottom_wall.SetActive(false);
                right_wall.SetActive(false);
                left_wall.SetActive(false);
            }
            else if (Input.GetKey("s"))
            {
                bottom_wall.SetActive(true);
                top_wall.SetActive(false);
                right_wall.SetActive(false);
                left_wall.SetActive(false);
            }
            else if (Input.GetKey("d"))
            {
                right_wall.SetActive(true);
                bottom_wall.SetActive(false);
                top_wall.SetActive(false);
                left_wall.SetActive(false);
            }
            else if (Input.GetKey("a"))
            {
                left_wall.SetActive(true);
                bottom_wall.SetActive(false);
                right_wall.SetActive(false);
                top_wall.SetActive(false);
            }
        }
    }
}
