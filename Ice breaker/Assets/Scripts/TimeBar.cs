using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    private float timeRemaining;
    private float timeprev;
    private bool timerIsRunning = false;
    public int color = 1;
   public void Start(){
        timeRemaining = 10;
        timeprev = 10;
        Debug.Log(FindObjectOfType<GameManager>().NumerOfBrickCleared());
    //    if(FindObjectOfType<GameManager>().NumerOfBrickCleared()[0]==0){
    //         Color c = new Color(0f/255f, 0f/255f, 255f/255f, 1);
    //         slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c;
    //         timeRemaining = 30;
    //         timeprev = 30;
    //         color +=1;
    //        if(FindObjectOfType<GameManager>().NumerOfBrickCleared()[1]==0){
    //             c = new Color(255f/255f, 255f/255f, 0f/255f, 1);
    //             slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c;
    //             timerIsRunning = false;
    //        }
    //    }
       SetTimer(100);
       timerIsRunning = true;
   }
   void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                SetTimer((int)(timeRemaining*100/timeprev));
                // if(FindObjectOfType<GameManager>().NumerOfBrickCleared()[color-1]==0){
                //     timeRemaining =0;
                // }
            }
            else
            {
                if(color == 1){
                    SetMaxTime(100);
                    Color c = new Color(0f/255f, 0f/255f, 255f/255f, 1);
                    slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c; 
                    timeRemaining = 20;
                    timeprev = 20;
                    color +=1;
                }
                else if(color == 2){
                    SetMaxTime(100);
                    Color c = new Color(255f/255f, 255f/255f, 0f/255f, 1);
                    slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c; 
                    timerIsRunning = false;
                    color +=1;
                }
            }
        }
    }
   public void SetTimer(int time){
       slider.value = time;
       Debug.Log(slider.value + "Value");
   }
   public void SetMaxTime( int time){
       slider.maxValue = time;
       slider.value = time;
       Debug.Log(slider.value + "start Value");
   }
}   
