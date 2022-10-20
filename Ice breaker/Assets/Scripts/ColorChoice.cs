using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChoice : MonoBehaviour
{
    //public Button red_button;
    //private int color;
    // Start is called before the first frame update
   /*
    void OnMouseDown()
   {
       Color c = this.GetComponent<SpriteRenderer>().color;
       //c = new Color(c.r* 255.0f, c.g * 255.0f, c.b * 255.0f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);

   }
   */
   public void SelectColorRed()
   {
       //Color c = this.GetComponent<SpriteRenderer>().color;
       Color c = new Color(149f/255f, 73f/255f, 62f/255f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);

   }
   
   public void SelectColorBlue()
   {
       //Color c = this.GetComponent<SpriteRenderer>().color;
       Color c = new Color(60f/255f, 75f/255f, 161f/255f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);

   }
   
   public void SelectColorYellow()
   {
       //Color c = this.GetComponent<SpriteRenderer>().color;
       Color c = new Color(178f/255f, 150f/255f, 53f/255f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);

   }
}
