using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedBrick : MonoBehaviour
{
    private GameObject progressBar;
    public bool hasTimer = true;
    private bool startTimer = true;
    public float totalTime = 5.0f;
    private float currentTime;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.startTimer = true;
        this.currentTime = this.totalTime;
        
        if(hasTimer) 
        {
            progressBar = gameObject.transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTimer && startTimer) {
            if(currentTime > 0) {
                this.currentTime -= Time.deltaTime;
                Vector3 pLocalScale = progressBar.transform.localScale;
                pLocalScale.x = 0.5f*(this.currentTime/this.totalTime) ;
                progressBar.transform.localScale = pLocalScale;
            }
            else 
            {
                startTimer = false;
                Destroy(gameObject);
            }
        }
    }
}
