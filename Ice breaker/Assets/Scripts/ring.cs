using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    // Start is called before the first frame update
    public EdgeCollider2D edg_collider;
    private bool ball_inside;
    private float rot_ang;
    void Start()
    {
        ball_inside = false;
        rot_ang = 6.0f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, rot_ang);
        KeyCode spacekey = KeyCode.Space;
        if(Input.GetKeyDown(spacekey))
        {
            //this.transform.rotation = Quaternion.Euler(-this.transform.rotation.x, -this.transform.rotation.y,
              //  -this.transform.rotation.z);
              rot_ang = -1 * rot_ang;
        }
        /*
        if (edg_collider.isTrigger == true)
        {
            Debug.Log("ball entered");
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ball_inside == true)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            collision.gameObject.GetComponent<Rigidbody2D>().drag = 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            Debug.Log("Ball entered");
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            // other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, -2.8f, 0.0f), ForceMode2D.Impulse);
            ball_inside = true;
            
        }
        
    }
    
}
