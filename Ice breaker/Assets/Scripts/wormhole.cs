using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    private float wormholeCooldownTime = 0.2f;
    static private float nextCollisionMinTime;
    static private GameObject teleportedWormhole = null;
    public bool outgoingCollision = false;
    
    void Start(){
        nextCollisionMinTime = 0;
    }

    private GameObject level_16_get_other_wormhole(GameObject gameObject){
        GameObject otherWormhole = GameObject.FindWithTag("level-16-bottomrightWormhole");
        if(gameObject.tag == "level-16-topleftWormhole"){
            otherWormhole = GameObject.FindWithTag("level-16-bottomrightWormhole");
        }
        else if(gameObject.tag == "level-16-toprightWormhole"){
            otherWormhole = GameObject.FindWithTag("level-16-bottomleftWormhole");
        }
        else if(gameObject.tag == "level-16-bottomleftWormhole"){
            otherWormhole = GameObject.FindWithTag("level-16-toprightWormhole");
        }
        else{
            otherWormhole = GameObject.FindWithTag("level-16-topleftWormhole");
        }
        return otherWormhole;
    }

    private GameObject level_16_get_src_wormholes(GameObject gameObject)
    {
        if(gameObject.tag == "level-16-bottomleftWormhole"){
            return GameObject.FindWithTag("level-16-toprightWormhole");
        }
        else{
            return GameObject.FindWithTag("level-16-bottomrightWormhole");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("on collision: ");
        if(teleportedWormhole != null){
            teleportedWormhole = null;
            return;
        }

        if (collision.gameObject.name == "Ball" ){
            Debug.Log(Time.time);
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if (ball != null)
            {   
                GameObject otherWormhole = level_16_get_other_wormhole(gameObject);
                float newAngle = -1 * Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);

                Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

                Color black_color = new Color(0f, 0f, 0f, 1f);
                Color white_color = new Color(1f, 1f, 1f, 1f);

                ball.transform.position = otherWormhole.transform.position;

                if (ball.GetComponent<SpriteRenderer>().color == black_color){
                    ball.GetComponent<SpriteRenderer>().color = white_color; 
                }
                else{
                    ball.GetComponent<SpriteRenderer>().color = black_color;
                }
                nextCollisionMinTime = Time.time + wormholeCooldownTime;
                teleportedWormhole = this.gameObject;
            }
        }
        
        // level-16 wormhole config
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Brick"){
                Brick brick = collision.gameObject.GetComponent<Brick>();
                if (brick != null)
                {   
                    if (true ){
                            GameObject otherWormhole = level_16_get_other_wormhole(gameObject);
                            //Destroy(brick.gameObject);
                            collision.gameObject.transform.position = otherWormhole.transform.position;

                            float newAngle = Vector2.SignedAngle(Vector2.up, brick.GetComponent<Rigidbody2D>().velocity);

                            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                            brick.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * brick.GetComponent<Rigidbody2D>().velocity.magnitude;
                            nextCollisionMinTime = Time.time + wormholeCooldownTime;
                            teleportedWormhole = this.gameObject;
                    }
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(outgoingCollision){
            outgoingCollision = false;
            return;
        }
    
        if(collision.gameObject.tag == "Brick"){
            Brick brick = collision.gameObject.GetComponent<Brick>();
            if (brick != null)
            {   
                if (true){
                    GameObject otherWormhole = level_16_get_other_wormhole(gameObject);
                    //Destroy(brick.gameObject);
                    collision.gameObject.transform.position = otherWormhole.transform.position;

                    float newAngle = Vector2.SignedAngle(Vector2.up, brick.GetComponent<Rigidbody2D>().velocity);

                    Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                    brick.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * brick.GetComponent<Rigidbody2D>().velocity.magnitude;
                    nextCollisionMinTime = Time.time + wormholeCooldownTime;
                    otherWormhole.GetComponent<Wormhole>().outgoingCollision = true;
                }
            }
        }
    }

}
