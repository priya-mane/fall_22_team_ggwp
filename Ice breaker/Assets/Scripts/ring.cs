using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    // Start is called before the first frame update
    public EdgeCollider2D edg_collider;
    private bool ball_inside;
    private float rot_ang;
    private int flag =1;
    void Start()
    {
        ball_inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        // KeyCode spacekey = KeyCode.Space;
        if(Input.GetKeyDown("space"))
        {
            // this.transform.rotation = Quaternion.Euler(-this.transform.rotation.x, -this.transform.rotation.y,
            //    -this.transform.rotation.z);
             flag *= -1;
        }
        rot_ang = flag *50.0f * 0.008f;
        // for local
        rot_ang = flag *5.0f * 0.008f;
        this.transform.Rotate(0,0,rot_ang);
       // Debug.Log(rot_ang);
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
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            // other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.0f, -2.8f, 0.0f), ForceMode2D.Impulse);
            ball_inside = true;
            
        }
        
    }
    
}
