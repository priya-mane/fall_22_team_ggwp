using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChoice : MonoBehaviour
{
    private int color;
    // Start is called before the first frame update
   void OnMouseDown()
   {
       Color c = this.GetComponent<SpriteRenderer>().color;
       //c = new Color(c.r* 255.0f, c.g * 255.0f, c.b * 255.0f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);

   }
}
