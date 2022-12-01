using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickCount : MonoBehaviour
{
    // Start is called before the first frame update
    private int maxBricks = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TMPro.TextMeshProUGUI txtMy = this.GetComponent<TMPro.TextMeshProUGUI>();
        txtMy.text = "Brick: " + (maxBricks - GameManager.crushedBricks);
    }
}
