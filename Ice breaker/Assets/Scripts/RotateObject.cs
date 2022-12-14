using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour
{
     private Camera myCam;
     private Vector3 screenPos;
     private float angleOffset;
    public float maxBounceAngle = 60f;
     void Start () {
         myCam=Camera.main;
     }
    private void OnMouseDown()
    {
        // Debug.Log(this.gameObject.name);
        GameManager.selectedObject = this.gameObject;
              
    }
     void Update () 
     { 

        if (GameManager.selectedObject == this.gameObject)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0,0, 20 * Time.deltaTime); 
            } 
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0,0, -20 * Time.deltaTime); 
            }
        }

     }

    
}
