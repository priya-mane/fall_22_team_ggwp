using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float zCord;

    void OnMouseDown(){
        zCord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMosPosition();
        GameManager.selectedObject = this.gameObject;
    }
    private Vector3 GetMosPosition(){
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zCord;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void OnMouseDrag(){
        transform.position = GetMosPosition() + mOffset;
    }
}
