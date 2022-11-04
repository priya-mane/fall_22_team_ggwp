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

    private Color red_color;
    private Color blue_color;
    private Color yellow_color;
   public void Start(){

        red_color = new Color(149f/255f,73f/255f,62f/255f,1);
        blue_color = new Color(60f/255f,75f/255f,161f/255f,1);
        yellow_color = new Color(178f/255f,150f/255f,53f/255f,1);

        timeRemaining = 20;
        timeprev = 20;
        timerIsRunning = true;
        int[] n = FindObjectOfType<GameManager>().NumerOfBrickCleared();
        slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = red_color;
        
        if(n[0]==0){
                Color c = blue_color;
                slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c;
                timeRemaining = 40;
                timeprev = 40;
                color +=1;
            if(n[1]==0){
                    c = yellow_color;
                    slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c;
                    timerIsRunning = false;
            }
        }
        SetMaxTime(100);
   }
   void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                SetTimer((int)(timeRemaining*100/timeprev));
                
            }
            else
            {
                if(color == 1){
                    SetMaxTime(100);
                    Color c = blue_color;
                    slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c; 
                    timeRemaining = 20;
                    timeprev = 20;
                    color +=1;
                }
                else if(color == 2){
                    SetMaxTime(100);
                    Color c = yellow_color;
                    slider.gameObject.transform.Find("Fill").GetComponent<Image>().color = c; 
                    timerIsRunning = false;
                    color +=1;
                }
            }
        }
    }
   public void SetTimer(int time){
       slider.value = time;
   }
   public void SetMaxTime( int time){
       slider.maxValue = time;
       slider.value = time;

   }
}   
