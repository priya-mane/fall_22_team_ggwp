using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "TopWall" || collision.gameObject.name == "RightWall" ||
            collision.gameObject.name == "LeftWall" || collision.gameObject.name == "BottomWall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag=="safetyWall")
        {
            GameManager.coinsCollected += 1;
            Destroy(this.gameObject);
        }
    }
}
