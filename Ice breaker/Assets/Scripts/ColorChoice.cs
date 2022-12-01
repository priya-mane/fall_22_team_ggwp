using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Button RedButton;
    public Button BlueButton;
    public Button YellowButton;
    public Sprite RedNewSprite;
    public Sprite BlueNewSprite;
    public Sprite YellowNewSprite;
    private int colorSet = -1;
    private Sprite oldSprite = null;

    List<Color> colors = new List<Color>(){
            new Color(149f/255f, 73f/255f, 62f/255f, 1),
            new Color(60f/255f, 75f/255f, 161f/255f, 1),
            new Color(178f/255f, 150f/255f, 53f/255f, 1)
        };
    private int counter = 0;
   void Update() 
   {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            counter = (counter+1)%3;
            
            if(counter == 0){
                if (colorSet != -1){
                    RevertSpriteChange();
                }
                oldSprite =  RedButton.GetComponent<Image>().sprite;
                RedButton.GetComponent<Image>().sprite = RedNewSprite;
                colorSet = 0;
            }
            else if(counter == 1 ){
                if (colorSet != -1){
                    RevertSpriteChange();
                }
                oldSprite =  BlueButton.GetComponent<Image>().sprite;
                BlueButton.GetComponent<Image>().sprite = BlueNewSprite;
                colorSet = 1;
            }
            else if(counter == 2 ){
                if (colorSet != -1){
                    RevertSpriteChange();
                }
                oldSprite =  YellowButton.GetComponent<Image>().sprite;
                YellowButton.GetComponent<Image>().sprite = YellowNewSprite;
                colorSet = 2;
            }
            FindObjectOfType<GameManager>().SetBallColor(colors[counter]);

        }
   }
   public void SelectColorRed()
   {
       if (colorSet != -1){
            RevertSpriteChange();
        }
       oldSprite =  RedButton.GetComponent<Image>().sprite;
       counter = 0;
       colorSet = 0;
       Color c = new Color(149f/255f, 73f/255f, 62f/255f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);
       RedButton.GetComponent<Image>().sprite= RedNewSprite;
   }
   
   public void SelectColorBlue()
   {
        if (colorSet != -1){
            RevertSpriteChange();
        }
       oldSprite =  BlueButton.GetComponent<Image>().sprite;
       counter = 1;
       colorSet = 1;
       Color c = new Color(60f/255f, 75f/255f, 161f/255f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);
        BlueButton.GetComponent<Image>().sprite= BlueNewSprite;
   }
   
   public void SelectColorYellow()
   {
        if (colorSet != -1){
            RevertSpriteChange();
        }
       oldSprite =  YellowButton.GetComponent<Image>().sprite;
       counter = 2;
       colorSet = 2;
       Color c = new Color(178f/255f, 150f/255f, 53f/255f, 1);
       FindObjectOfType<GameManager>().SetBallColor(c);
    YellowButton.GetComponent<Image>().sprite= YellowNewSprite;
   }

   private void RevertSpriteChange(){
       if( colorSet == 0){
           RedButton.GetComponent<Image>().sprite = oldSprite; 
       }
       else if (colorSet ==1){
           BlueButton.GetComponent<Image>().sprite = oldSprite; 
       }
       else{
           YellowButton.GetComponent<Image>().sprite = oldSprite; 
       }
   }
}
