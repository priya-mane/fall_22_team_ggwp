using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float zCord;
    public bool vertical;
    public GameObject leftWall;
    public GameObject rightWall;

    void OnMouseDown(){
        zCord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMosPosition();
        GameManager.selectedObject = this.gameObject;
    }
    private Vector3 GetMosPosition(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zCord;
        if(vertical){
            mousePosition.x = 0f;
        }
        else{
            mousePosition.y = 0f;
        }
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void OnMouseDrag(){
        var v = GetMosPosition() + mOffset;
        if(v.x < leftWall.transform.position.x){
            v.x = leftWall.transform.position.x;
        }else if(v.x > rightWall.transform.position.x){
            v.x = rightWall.transform.position.x;
        }
        transform.position = v;
    }
}