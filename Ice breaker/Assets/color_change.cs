using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_change : MonoBehaviour
{
    // Start is called before the first frame update
    private int nextTime = 0;
    private int interval = 1;
    Color[] colors_ = {new Color(149f/255f,73f/255f,62f/255f,1), new Color(60f/255f,75f/255f,161f/255f,1), new Color(178f/255f,150f/255f,53f/255f,1)};
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            Debug.Log(colors_[nextTime % 3]);
            this.GetComponent<SpriteRenderer>().color = colors_[nextTime % 3];
            nextTime += interval;
        }
    }
}
