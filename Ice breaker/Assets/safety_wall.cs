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
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            Debug.Log("up arrow key pressed");
            top_wall.SetActive(true);
            bottom_wall.SetActive(false);
            right_wall.SetActive(false);
            left_wall.SetActive(false);
        }
        else if (Input.GetKey("down"))
        {
            bottom_wall.SetActive(true);
            top_wall.SetActive(false);
            right_wall.SetActive(false);
            left_wall.SetActive(false);
        }
        else if (Input.GetKey("right"))
        {
            right_wall.SetActive(true);
            bottom_wall.SetActive(false);
            top_wall.SetActive(false);
            left_wall.SetActive(false);
        }
        else if (Input.GetKey("left"))
        {
            left_wall.SetActive(true);
            bottom_wall.SetActive(false);
            right_wall.SetActive(false);
            top_wall.SetActive(false);
        }
        
    }
}
